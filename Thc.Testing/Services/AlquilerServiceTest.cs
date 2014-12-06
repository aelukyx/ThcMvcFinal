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
    public class AlquilerServiceTest
    {
        private Mock<ThcEntities> entitiesMock;

        [SetUp]
        public void SetUp()
        {
            //  Arrange 
            var db = AlquilerFakeDB();
            var mockDbset = new Mock<IDbSet<Alquiler>>();
            mockDbset.Setup(x => x.Provider).Returns(db.Provider);
            mockDbset.Setup(x => x.Expression).Returns(db.Expression);
            mockDbset.Setup(x => x.ElementType).Returns(db.ElementType);
            mockDbset.Setup(x => x.GetEnumerator()).Returns(db.GetEnumerator);
            entitiesMock = new Mock<ThcEntities>();
            entitiesMock.Setup(x => x.Alquileres).Returns(mockDbset.Object);
        }

        [Test]
        public void _01_TestAllReturnIListPost()
        {
            var service = new AlquilerService(entitiesMock.Object);

            var result = service.All();

            Assert.IsInstanceOf(typeof(IList<Alquiler>), result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void _02_TestGetByIdReturnPostIsOk()
        {

            var service = new AlquilerService(entitiesMock.Object);

            var result = service.GetById(1);

            Assert.AreEqual("La Colpa", result.LugarReferencia);
            Assert.AreEqual(1, result.ConductorId);
        }


        [Test]
        public void _03_TestInsertCreateNewRow()
        {

            var service = new AlquilerService(entitiesMock.Object);

            service.Insert(new Alquiler { LugarReferencia = "La Colpa", ConductorId = 1 });
        }


        private IQueryable<Alquiler> AlquilerFakeDB()
        {
            return new List<Alquiler>
            {
                new Alquiler { Id = 1, LugarReferencia = "La Colpa", ConductorId = 1},
                new Alquiler { Id = 2, LugarReferencia = "Llacanora", ConductorId = 2},

            }.AsQueryable();
        }
    }
}
