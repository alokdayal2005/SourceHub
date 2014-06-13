using System.Web.UI;
using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MovieReview.Controllers
{
    public class HomeController : Controller
    {
        //MovieDb _movieDb = new MovieDb();
        private IMovieDb _movieDb;

        public HomeController()
        {
            _movieDb= new MovieDb();
        }

        public HomeController(IMovieDb moviedb)
        {
            _movieDb = moviedb;
        }
         //[OutputCache(CacheProfile = "Short", Location = OutputCacheLocation.Server, VaryByHeader = "Accept-Language")]
        public ActionResult Index(string SearchQuery = null,int page=1)
        {
             
            var model = _movieDb.Query<Movie>()
                        .OrderByDescending(m => m.reviews.Count())
                        .Where(m => SearchQuery == null || m.MovieName.StartsWith(SearchQuery))
                        .Select(m => new MovieViewModel
                        {
                            Id = m.Id,
                            MovieName = m.MovieName,
                            DirectorName = m.DirectorName,
                            ReleaseYear = m.ReleaseYear,
                            NoOfReviews = m.reviews.Count()
                        }).ToPagedList(page,10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_movies", model);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_movieDb != null)
            {
                _movieDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
