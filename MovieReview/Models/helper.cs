using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReview.Models
{
    public class helper
    {
        public Movie EnterMovie(Movie movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                MovieName = movie.MovieName,
                DirectorName = movie.DirectorName,
                ReleaseYear = movie.ReleaseYear
               
            };
        }
    }
}