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

namespace Thc.Testing.AutoControllerTest
{
    [TestFixture]
    public class AutoControllerTest
    {

        [Test]
        public void _01_TestAutoIndexReturnViewIsOk()
        {
            //Arrange
            var mock = new Mock<IAutoService>();
            mock.Setup(x => x.All()).Returns(new List<Auto>());
            var controller = new AutoController(mock.Object);

            // Act

            var view = controller.Index();

            //Assert
            mock.Verify(x => x.All(), Times.Once);
            AssertViewsWithModel(view, "Index");
            Assert.IsInstanceOf(typeof(List<Auto>), view.Model);
        }

        [Test]
        public void _02_TestAutoCreateReturnViewIsOk()
        {
            var mock = new Mock<IAutoService>();
            
            mock.Setup(x => x.GetUnidades()).Returns(new List<Unidad>());
            mock.Setup(x => x.GetEstados()).Returns(new List<Estado>());

            var controller = new AutoController(mock.Object);

            var view = controller.Create() as ViewResult;

            AssertViewWithoutModel(view, "Create");

        }

        [Test]
        public void _03_TestAutoSaveSuccessRedirectToIndex()
        {
            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var redirect = controller.Create(new Auto { Placa="SW-3652" }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _04_TestAutoDetailsRedirectToIndexWhenIdIsZero()
        {
            // Arrange

            var controller = new AutoController(null);

            // Act

            var redirect = controller.Details(0) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _05_TestAutoDetailsreturnViewIsOk()
        {
            // Arrange
            var mock = new Mock<IAutoService>();
            mock.Setup(x => x.GetById(1)).Returns(new Auto { });
            var controller = new AutoController(mock.Object);

            // Act

            var view = controller.Details(1) as ViewResult;

            //Assert
            AssertViewsWithModel(view, "Details");
            Assert.IsInstanceOf(typeof(Auto), view.Model);
        }

        [Test]
        public void _06_TestAutoGuardadoCorrectamenteRedirectToIndex()
        {
            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var redirect = controller.Create(new Auto
            {
                Placa = "RT-1467",
                EstadoId = 1,
                UnidadId = 1
            }) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [Test]
        public void _07_TestAutoEditReturnViewIsOk()
        {
            var mock = new Mock<IAutoService>();
            mock.Setup(x => x.GetById(1)).Returns(new Auto());

            var controller = new AutoController(mock.Object);

            var view = controller.Edit(1) as ViewResult;

            AssertViewsWithModel(view, "edit");
            mock.Verify(x => x.GetById(1), Times.Exactly(1));

        }
        [Test]
        public void _08_TestAutoEditEditSaveSuccess()
        {
            //arrange
            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var redirect = controller.Edit(new Auto { Placa = "PE-7162" }) as RedirectToRouteResult;

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