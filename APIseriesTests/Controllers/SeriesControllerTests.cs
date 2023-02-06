using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIseries.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIseries.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace APIseries.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        private SeriesController controller;
        private SeriesDBContext context;

        [ClassInitialize]
        public void InitialisationDesTests()
        {
            var builder = new DbContextOptionsBuilder<SeriesDBContext>().UseNpgsql("Server=localhost;port=5432;Database=SeriesDB; uid=postgres;\npassword=postgres;"); // Chaine de connexion à mettre dans les ( )
            SeriesDBContext context = new SeriesDBContext(builder.Options);
            SeriesController controller = new SeriesController(context);
        }

        [TestMethod()]
        public void SeriesControllerTest()
        {

        }

        [TestMethod()]
        public void GetSeriesTest()
        {
            // Arrange

        }

        [TestMethod()]
        public void GetSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutSerieTest()
        {
            // Arrange

        }

        [TestMethod()]
        public void PostSerieTest()
        {
            // Arrange
            SeriesController controller = new SeriesController(context);
            Serie d = new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC");

            // Act
            var result = controller.PostSerie(d);
            //CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Serie>), "Pas un ActionResult"); // Test du type de result
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "Pas un CreatedAtRouteResult"); // Test du type de result.Result

            //Assert.AreEqual(routeResult.StatusCode, StatusCodes.Status201Created, "Les status codes ne sont pas egaux"); // Test des status code
            Assert.AreEqual(new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC"), (Serie?)routeResult.Value, ""); // Test de la devise stocké

        }

        [TestMethod()]
        public void DeleteSerieTest()
        {
            Assert.Fail();
        }
    }
}