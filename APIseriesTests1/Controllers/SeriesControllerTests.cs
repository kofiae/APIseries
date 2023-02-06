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
using Microsoft.AspNetCore.Rewrite;

namespace APIseries.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        public SeriesController controller;
        private List<Serie> listeSeriesRecuperees;

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
        public void GetSeriesTest_Ok_ReturnsListSeries()
        {
            // Act
            var result = controller.GetSeries();
            listeSeriesRecuperees.Where(s => s.Serieid <= 3).ToList();

            // Arrange
            CollectionAssert.AreEqual(listeSeriesRecuperees, (System.Collections.ICollection?)result);
        }

        [TestMethod()]
        public void GetSerieTest_OK_ReturnSerie()
        {
            // Arrange
            int d = 1;
            Serie s = new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");

            // Act
            var result = controller.GetSerie(d);
            //Serie r = (Serie)result.valu;

            // Assert
            Assert.AreEqual<Serie>(s, s, "Le programme ne renvoie pas la bonne série");
        }

        [TestMethod()]
        public void GetSerieTest_NotOK_ReturnsNotFound()
        {
            // Arrange
            int d = 100;

            // Act
            var result = controller.GetSerie(d);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void PutSerieTest_NotOK_ReturnsAggregateException()
        {
            // Arrange
            Serie d = new Serie(100, "once upon a time", 6, 120, 2009, "ABC");

            // Act
            var result = controller.PutSerie(1, d);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AggregateException), "L'erreur doit être AggregateException");
        }

        [TestMethod()]
        public void PostSerieTest_NotOK_ReturnsAggregateException()
        {
            // Arrange
            Serie d = new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC");

            // Act
            var result = controller.PostSerie(d);
            
            //Assert
            Assert.IsInstanceOfType(result, typeof(AggregateException), "Eurreur dans les données entrées");
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
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "L'erreur doit être NotFound");

        }

        public void DeleteSerieTest_Ok_ReturnsNotFound()
        {
            // Arrange
            Serie d = new Serie(100, "once upon a time", "too long", 6, 120, 2009, "ABC");

            // Act 
            var result = controller.DeleteSerie(d.Serieid);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult), "Le retour doit être NoContentResult");

        }
    }
}