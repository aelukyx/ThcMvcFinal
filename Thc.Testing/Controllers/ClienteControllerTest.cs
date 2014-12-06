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

namespace Thc.Testing.ClienteControllerTest
{
    [TestFixture]
    public class ClienteControllerTest
    {

        [Test]
        public void _01_TestClienteIndexReturnViewIsOk()
        {
            //Arrange
            var mock = new Mock<IClienteService>();
            mock.Setup(x => x.All()).Returns(new List<Cliente>());
            var controller = new ClienteController(mock.Object);

            // Act

            var view = controller.Index();

            //Assert
            mock.Verify(x => x.All(), Times.Once);
            AssertViewsWithModel(view, "Index");
            Assert.IsInstanceOf(typeof(List<Cliente>), view.Model);
        }

        [Test]
        public void _02_TestClienteCreateReturnViewIsOk()
        {
            var controller = new ClienteController(null);

            var view = controller.Create() as ViewResult;

            AssertViewWithoutModel(view, "Create");

        }

        [Test]
        public void _03_TestClienteSaveSuccessRedirectToIndex()
        {
            var mock = new Mock<IClienteService>();
            var controller = new ClienteController(mock.Object);

            var redirect = controller.Create(new Cliente { NombresRazonSocial = "Juan Francisco" }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _04_TestClienteDetailsRedirectToIndexWhenIdIsZero()
        {
            // Arrange

            var controller = new ClienteController(null);

            // Act

            var redirect = controller.Details(0) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _05_TestClienteDetailsreturnViewIsOk()
        {
            // Arrange
            var mock = new Mock<IClienteService>();
            mock.Setup(x => x.GetById(1)).Returns(new Cliente { });
            var controller = new ClienteController(mock.Object);

            // Act

            var view = controller.Details(1) as ViewResult;

            //Assert
            AssertViewsWithModel(view, "Details");
            Assert.IsInstanceOf(typeof(Cliente), view.Model);
        }

        [Test]
        public void _06_TestClienteGuardadoCorrectamenteRedirectToIndex()
        {
            var mock = new Mock<IClienteService>();
            var controller = new ClienteController(mock.Object);

            var redirect = controller.Create(new Cliente
            {
                TipoDoc = true,
                DniRuc = "71621467",
                NombresRazonSocial = "Alexander Raúl",
                AppPaterno = "Cabrera",
                AppMaterno = "Guevara",
                Celular = 978258847,
                Telefono = "(76)506349"
            }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _07_TestClienteEditReturnViewIsOk()
        {
            var mock = new Mock<IClienteService>();
            mock.Setup(x => x.GetById(1)).Returns(new Cliente());

            var controller = new ClienteController(mock.Object);

            var view = controller.Edit(1) as ViewResult;

            AssertViewsWithModel(view, "edit");
            mock.Verify(x => x.GetById(1), Times.Exactly(1));

        }
        [Test]
        public void _08_TestClienteEditEditSaveSuccess()
        {
            //arrange
            var mock = new Mock<IClienteService>();
            var controller = new ClienteController(mock.Object);

            var redirect = controller.Edit(new Cliente { DniRuc = "7162146789" }) as RedirectToRouteResult;

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