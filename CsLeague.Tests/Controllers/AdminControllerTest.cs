using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsLeague.Controllers;
using System.Web.Mvc;
using CsLeague.Models;
using System.IO;

namespace CsLeague.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsWithNoValue()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void DetailsWithNonExistentValue()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            HttpNotFoundResult result = controller.Details(999) as HttpNotFoundResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void DetailsWithCorrectValue()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ActionResult result = controller.Details(1) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
