using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReview.Controllers
{
    public class MovieReviewsController : Controller
    {


        MovieDb _db = new MovieDb();
        //
        // GET: /MovieReviews/

        public ActionResult Index([Bind(Prefix = "id")] int movieId)
        {
            var movie = _db.Movies.Find(movieId);
            if (movie != null)
            {
                return View(movie);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int movieId)
        {
            return View();
        }

       
        [HttpPost]

        public ActionResult Create(MovieReviews _review)
        {
            if (ModelState.IsValid)
            {
                _db.MovieReviews.Add(_review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = _review.MovieId });
            }
            return View(_review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.MovieReviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieReviews review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.MovieId });
            }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }


}
