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

namespace Thc.Testing.ProveedorControllerTest
{
    [TestFixture]
    public class ProveedorControllerTest
    {

        [Test]
        public void _01_TestProveedorIndexReturnViewIsOk()
        {
            //Arrange
            var mock = new Mock<IProveedorService>();
            mock.Setup(x => x.All()).Returns(new List<Proveedor>());
            var controller = new ProveedorController(mock.Object);

            // Act

            var view = controller.Index();

            //Assert
            mock.Verify(x => x.All(), Times.Once);
            AssertViewsWithModel(view, "Index");
            Assert.IsInstanceOf(typeof(List<Proveedor>), view.Model);
        }

        [Test]
        public void _02_TestProveedorCreateReturnViewIsOk()
        {
            var mock = new Mock<IProveedorService>();
            //*/.z
            mock.Setup(x => x.GetCiudades()).Returns(new List<Ciudad>());

            var controller = new ProveedorController(mock.Object);

            var view = controller.Create() as ViewResult;

            AssertViewWithoutModel(view, "Create");

        }

        [Test]
        public void _03_TestProveedorSaveSuccessRedirectToIndex()
        {
            var mock = new Mock<IProveedorService>();
            var controller = new ProveedorController(mock.Object);

            var redirect = controller.Create(new Proveedor { RazonSocial = "Juan Francisco" }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _04_TestProveedorDetailsRedirectToIndexWhenIdIsZero()
        {
            // Arrange

            var controller = new ProveedorController(null);

            // Act

            var redirect = controller.Details(0) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _05_TestProveedorDetailsreturnViewIsOk()
        {
            // Arrange
            var mock = new Mock<IProveedorService>();
            mock.Setup(x => x.GetById(1)).Returns(new Proveedor { });
            var controller = new ProveedorController(mock.Object);

            // Act

            var view = controller.Details(1) as ViewResult;

            //Assert
            AssertViewsWithModel(view, "Details");
            Assert.IsInstanceOf(typeof(Proveedor), view.Model);
        }

        [Test]
        public void _06_TestProveedorGuardadoCorrectamenteRedirectToIndex()
        {
            var mock = new Mock<IProveedorService>();
            var controller = new ProveedorController(mock.Object);

            var redirect = controller.Create(new Proveedor
            {
                NroRUC = "71621467",
                RazonSocial = "Alexander Raúl"
            }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _07_TestProveedorEditReturnViewIsOk()
        {
            var mock = new Mock<IProveedorService>();
            mock.Setup(x => x.GetById(1)).Returns(new Proveedor());

            var controller = new ProveedorController(mock.Object);

            var view = controller.Edit(1) as ViewResult;

            AssertViewsWithModel(view, "edit");
            mock.Verify(x => x.GetById(1), Times.Exactly(1));

        }
        [Test]
        public void _08_TestProveedorEditEditSaveSuccess()
        {
            //arrange
            var mock = new Mock<IProveedorService>();
            var controller = new ProveedorController(mock.Object);

            var redirect = controller.Edit(new Proveedor { NroRUC = "7162146789" }) as RedirectToRouteResult;

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