using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReview.Models;

namespace MovieReview.Tests.UnitTests
{
    class TestData
    {
        public static IQueryable<Movie> Movies
        {
            get
            {
                var movies = new List<Movie>();
                for (int i = 0; i < 200; i++)
                {
                    var movie = new Movie();
                    movie.reviews = new List<MovieReviews>()
                    {
                        new MovieReviews{ReviewerRating = 5}
                    };
                }
                return movies.AsQueryable();
            }
        }
    }
}
