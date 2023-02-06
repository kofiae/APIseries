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
        public SeriesController controller;


        [ClassInitialize]
        public void InitialisationDesTests()
        {
            var builder = new DbContextOptionsBuilder<SeriesDBContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=odufol; uid=odufol; password=DcwZaG; SearchPath=tp2"); // Chaine de connexion à mettre dans les ( )
            SeriesDBContext context = new SeriesDBContext(builder.Options);
            controller = new SeriesController(context);
        }

        [TestMethod()]
        public void SeriesControllerTest()
        {

        }

        [TestMethod()]
        public void GetSeriesTest()
        {
            // Arrange
            var result = controller.GetSeries();
            //List<Serie> l = result.Where(s => s.Serieid <= 3).ToList();
        }

        [TestMethod()]
        public void GetSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutSerieTest_NotValid()
        {
            // Arrange
            Serie d = new Serie(100, "once upon a time", 6, 120, 2009, "ABC");

            // Act
            var result = controller.PutSerie(1,d);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AggregateException), "L'erreur doit être AggregateException");
        }

        [TestMethod()]
        public void PostSerieTest()
        {
            // Arrange
            Serie d = new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC");

            // Act
            var result = controller.PostSerie(d);
            //CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Serie>), "Pas un ActionResult"); // Test du type de result
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "Pas un CreatedAtRouteResult"); // Test du type de result.Result

            //Assert.AreEqual(routeResult.StatusCode, StatusCodes.Status201Created, "Les status codes ne sont pas egaux"); // Test des status code
            //Assert.AreEqual(new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC"), (Serie?)routeResult.Value, ""); // Test de la devise stocké

        }

        [TestMethod()]
        public void DeleteSerieTest_NotOk_ReturnsNotFound()
        {
            // Arrange
            Serie d = new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC");

            // Act 
            var result = controller.DeleteSerie(d.Serieid);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "L'erreur doit être NotFound"); // Test du type de l'erreur

        }
    }
}