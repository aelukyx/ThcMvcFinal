using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;
using System.Web.Mvc;

using Thc.Web.Controllers;
using Thc.Interfaces.Services;
using Thc.Models.Models;
using Thc.Services.Services;

namespace Thc.Testing.AlquilerControllerTest
{
    [TestFixture]
    public class AlquilerControllerTest
    {

        [Test]
        public void _01_TestAlquilerIndexReturnViewIsOk()
        {
            //Arrange
            var mock = new Mock<IAlquilerService>();
            mock.Setup(x => x.All()).Returns(new List<Alquiler>());
            var controller = new AlquilerController(mock.Object);

            // Act

            var view = controller.Index();

            //Assert
            mock.Verify(x => x.All(), Times.Once);
            AssertViewsWithModel(view, "Index");
            Assert.IsInstanceOf(typeof(List<Alquiler>), view.Model);
        }

        [Test]
        public void _02_TestAlquilerCreateReturnViewIsOk()
        {
            var mock = new Mock<IAlquilerService>();
            //*/.z
            mock.Setup(x => x.GetClientes()).Returns(new List<Cliente>());
            mock.Setup(x => x.GetAutos()).Returns(new List<Auto>());
            mock.Setup(x => x.GetConductores()).Returns(new List<Conductor>());

            var controller = new AlquilerController(mock.Object);

            var view = controller.Create() as ViewResult;

            AssertViewWithoutModel(view, "Create");

        }

        [Test]
        public void _03_TestAlquilerSaveSuccessRedirectToIndex()
        {
            var mock = new Mock<IAlquilerService>();
            var controller = new AlquilerController(mock.Object);

            var redirect = controller.Create(new Alquiler { LugarReferencia = "La Colpa" }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _04_TestAlquilerDetailsRedirectToIndexWhenIdIsZero()
        {
            // Arrange

            var controller = new AlquilerController(null);

            // Act

            var redirect = controller.Details(0) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _05_TestAlquilerDetailsreturnViewIsOk()
        {
            // Arrange
            var mock = new Mock<IAlquilerService>();
            mock.Setup(x => x.GetById(1)).Returns(new Alquiler { });
            var controller = new AlquilerController(mock.Object);

            // Act

            var view = controller.Details(1) as ViewResult;

            //Assert
            AssertViewsWithModel(view, "Details");
            Assert.IsInstanceOf(typeof(Alquiler), view.Model);
        }

        [Test]
        public void _06_TestAlquilerGuardadoCorrectamenteRedirectToIndex()
        {
            var mock = new Mock<IAlquilerService>();
            var controller = new AlquilerController(mock.Object);

            var redirect = controller.Create(new Alquiler
            {
                LugarReferencia = "Llacanora",
                MontoXdia = 15,
                ConductorId = 1,
                AutoId = 1
            }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _07_TestAlquilerEditReturnViewIsOk()
        {
            var mock = new Mock<IAlquilerService>();
            mock.Setup(x => x.GetById(1)).Returns(new Alquiler());

            var controller = new AlquilerController(mock.Object);

            var view = controller.Edit(1) as ViewResult;

            AssertViewsWithModel(view, "edit");
            mock.Verify(x => x.GetById(1), Times.Exactly(1));

        }
        [Test]
        public void _08_TestAlquilerEditEditSaveSuccess()
        {
            //arrange
            var mock = new Mock<IAlquilerService>();
            var controller = new AlquilerController(mock.Object);

            var redirect = controller.Edit(new Alquiler { ClienteId = 2, AutoId = 1, MontoTotal = 180 }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        private void AssertViewsWithModel(ViewResult view, string viewName)
        {
            Assert.IsNotNull(view, "Vista no puede ser nulo");
            Assert.AreEqual(viewName, view.ViewName);
            Assert.IsNotNull(view.Model);
        }

        private void AssertViewWithoutModel(ViewResult view, string viewName)
        {
            Assert.IsNotNull(view);
            Assert.AreEqual(viewName, view.ViewName);
            Assert.IsNull(view.Model);
        }
    }
}