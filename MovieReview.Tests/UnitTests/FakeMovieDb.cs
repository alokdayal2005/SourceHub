using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReview.Models;

namespace MovieReview.Tests.UnitTests
{
    public class FakeMovieDb : IMovieDb
    {
        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof (T)] as IQueryable<T>;
        }

        public void Dispose()
        {

        }

        public void AddSet<T>(IQueryable<T> objs)
        {
            Sets.Add(typeof(T),objs);
        }

        public Dictionary<Type,object> Sets = new Dictionary<Type, object>(); 
    }
}
