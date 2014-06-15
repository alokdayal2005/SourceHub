using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReview.Models;

namespace MovieReview.Controllers
{
    public class MoviesAPIController : ApiController
    {
        private IMovieDb _movieDb;

        public MoviesAPIController(IMovieDb movieDb)
        {
            _movieDb = movieDb;
        }
        public object Get()
        {
            //   _movieDb = new MovieDb();
            var results =
                _movieDb.Query<Movie>().OrderByDescending(m => m.reviews.Count())
                    .Select(m => new MovieViewModel
                    {
                        Id = m.Id,
                        MovieName = m.MovieName,
                        DirectorName = m.DirectorName,
                        ReleaseYear = m.ReleaseYear,
                        NoOfReviews = m.reviews.Count()
                    });
            return results;
        }

        public object Post([FromBody] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var context = new MovieDb();

                    //Check Duplicate
                    if (_movieDb.Query<Movie>().Any(m => m.Id == movie.Id))
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Entry with the Id already exist");
                    }
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var context = new MovieDb();

                    //If Id Not found
                    if (_movieDb.Query<Movie>().Any(m => m.Id == Id) == false)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Record Not found with the ID supplied");
                    }

                    //else delete
                    if (_movieDb.Query<Movie>().Any(m => m.Id == Id))
                    {
                        Movie movie = context.Movies.Find(Id);
                        context.Movies.Remove(movie);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put([FromBody] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var context = new MovieDb();

                    //If Id Not found
                    if (_movieDb.Query<Movie>().Any(m => m.Id == movie.Id) == false)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Record Not found with the ID supplied");
                    }

                    //If Id found, then go ahead and update the record

                    if (_movieDb.Query<Movie>().Any(m => m.Id == movie.Id))
                    {
                        context.Movies.AddOrUpdate(movie);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
