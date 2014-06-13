using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MovieReview.Models
{
    public interface IMovieDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }
    public class MovieDb :DbContext, IMovieDb
    {
        public MovieDb()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReviews> MovieReviews { get; set; }

        IQueryable<T> IMovieDb.Query<T>()
        {
            return Set<T>();
        }
    }
}