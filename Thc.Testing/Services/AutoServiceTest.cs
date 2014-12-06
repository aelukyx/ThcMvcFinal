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
    public class AutoServiceTest
    {
        private Mock<ThcEntities> entitiesMock;

        [SetUp]
        public void SetUp()
        {
            //  Arrange 
            var db = AutoFakeDB();
            var mockDbset = new Mock<IDbSet<Auto>>();
            mockDbset.Setup(x => x.Provider).Returns(db.Provider);
            mockDbset.Setup(x => x.Expression).Returns(db.Expression);
            mockDbset.Setup(x => x.ElementType).Returns(db.ElementType);
            mockDbset.Setup(x => x.GetEnumerator()).Returns(db.GetEnumerator);
            entitiesMock = new Mock<ThcEntities>();
            entitiesMock.Setup(x => x.Autos).Returns(mockDbset.Object);
        }

        [Test]
        public void _01_TestAllReturnIListPost()
        {
            var service = new AutoService(entitiesMock.Object);

            var result = service.All();

            Assert.IsInstanceOf(typeof(IList<Auto>), result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void _02_TestGetByIdReturnPostIsOk()
        {

            var service = new AutoService(entitiesMock.Object);

            var result = service.GetById(1);

            Assert.AreEqual("UI-4121", result.Placa);
            Assert.AreEqual(1, result.UnidadId);
        }


        [Test]
        public void _03_TestInsertCreateNewRow()
        {

            var service = new AutoService(entitiesMock.Object);

            service.Insert(new Auto { Placa = "UI-4121", UnidadId = 1 });
        }


        private IQueryable<Auto> AutoFakeDB()
        {
            return new List<Auto>
            {
                new Auto { Id = 1, Placa = "UI-4121", UnidadId = 1},
                new Auto { Id = 2, Placa = "UI-4122", UnidadId = 2},

            }.AsQueryable();
        }
    }
}
