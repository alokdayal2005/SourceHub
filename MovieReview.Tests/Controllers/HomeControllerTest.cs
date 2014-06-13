using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReview;
using MovieReview.Controllers;
using MovieReview.Models;
using MovieReview.Tests.UnitTests;

namespace MovieReview.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var db = new FakeMovieDb();
            db.AddSet(TestData.Movies);
            // Arrange
            HomeController controller = new HomeController(db);
           
            controller.ControllerContext = new FakeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
