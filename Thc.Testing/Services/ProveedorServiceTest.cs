using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Thc.DB.DB;
using Thc.Services.Services;
using Thc.Models.Models;
using Moq;
using System.Data.Entity;

namespace Demo.Test.Services
{
    [TestFixture]
    public class ProveedorServiceTest
    {
        private Mock<ThcEntities> entitiesMock;

        [SetUp]
        public void SetUp()
        {
            //  Arrange 
            var db = ProveedorFakeDB();
            var mockDbset = new Mock<IDbSet<Proveedor>>();
            mockDbset.Setup(x => x.Provider).Returns(db.Provider);
            mockDbset.Setup(x => x.Expression).Returns(db.Expression);
            mockDbset.Setup(x => x.ElementType).Returns(db.ElementType);
            mockDbset.Setup(x => x.GetEnumerator()).Returns(db.GetEnumerator);
            entitiesMock = new Mock<ThcEntities>();
            entitiesMock.Setup(x => x.Proveedores).Returns(mockDbset.Object);
        }

        [Test]
        public void _01_TestAllReturnIListPost()
        {
            var service = new ProveedorService(entitiesMock.Object);

            var result = service.All();

            Assert.IsInstanceOf(typeof(IList<Proveedor>), result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void _02_TestGetByIdReturnPostIsOk()
        {

            var service = new ProveedorService(entitiesMock.Object);

            var result = service.GetById(1);

            Assert.AreEqual("26547454121", result.NroRUC);
            Assert.AreEqual("Lorem ipsum", result.RazonSocial);
        }


        [Test]
        public void _03_TestInsertCreateNewRow()
        {

            var service = new ProveedorService(entitiesMock.Object);

            service.Insert(new Proveedor { NroRUC = "26547454121", RazonSocial = "Lorem ipsum" });
        }


        private IQueryable<Proveedor> ProveedorFakeDB()
        {
            return new List<Proveedor>
            {
                new Proveedor { Id = 1, NroRUC = "26547454121", RazonSocial = "Lorem ipsum"},
                new Proveedor { Id = 2, NroRUC = "26547454124", RazonSocial = "Lorem ipsum"},

            }.AsQueryable();
        }
    }
}
