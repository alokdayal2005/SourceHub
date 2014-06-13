using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReview.Models;

namespace MovieReview.Tests.UnitTests
{
   public class RateMovie
   {
       private Movie _movie;

       public RateMovie(Movie movie)
       {
           _movie = movie;
       }

      public RatingResult EvaluateRating(int numberOfReviews)
      {
          var result = new RatingResult();
          result.Rating = (int) _movie.reviews.Average(m => m.ReviewerRating);
          return result;
      }
   }
}
