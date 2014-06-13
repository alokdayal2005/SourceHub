using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReview.Controllers;
using MovieReview.Models;

namespace MovieReview.Tests.UnitTests
{

    //TO DO:-  This case will ensure those movies come 1st which has reviews.
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Evaluate_Result_For_One_Review()
        {
            // Organise

            var data = SetupMovieAndReviews(ratings: new[] {5});
            
            //Act

            var rater = new RateMovie(data);
            var result = rater.EvaluateRating(5);

            //Assert

            Assert.AreEqual(5,result.Rating);
        }

        [TestMethod]
        public void Evaluate_Result_For_Multiple_Reviews()
        {
            // Organise

            var data = SetupMovieAndReviews(ratings: new[] {3, 5});
          
            //Act

            var rater = new RateMovie(data);
            var result = rater.EvaluateRating(5);

            //Assert

            Assert.AreEqual(4, result.Rating);
        }

      
        private Movie SetupMovieAndReviews(params int[] ratings)
        {
            var movie = new Movie();
            movie.reviews = ratings.Select(m => new MovieReviews() {ReviewerRating = m})
                .ToList();
            return movie;
        }
    }
}
