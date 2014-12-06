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
    public class ClienteServiceTest
    {
        private Mock<ThcEntities> entitiesMock;

        [SetUp]
        public void SetUp()
        {
            //  Arrange 
            var db = ClienteFakeDB();
            var mockDbset = new Mock<IDbSet<Cliente>>();
            mockDbset.Setup(x => x.Provider).Returns(db.Provider);
            mockDbset.Setup(x => x.Expression).Returns(db.Expression);
            mockDbset.Setup(x => x.ElementType).Returns(db.ElementType);
            mockDbset.Setup(x => x.GetEnumerator()).Returns(db.GetEnumerator);
            entitiesMock = new Mock<ThcEntities>();
            entitiesMock.Setup(x => x.Clientes).Returns(mockDbset.Object);
        }

        [Test]
        public void _01_TestAllReturnIListPost()
        {
            var service = new ClienteService(entitiesMock.Object);

            var result = service.All();

            Assert.IsInstanceOf(typeof(IList<Cliente>), result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void _02_TestGetByIdReturnPostIsOk()
        {

            var service = new ClienteService(entitiesMock.Object);

            var result = service.GetById(1);

            Assert.AreEqual("71621467", result.DniRuc);
            Assert.AreEqual("Lorem ipsum", result.NombresRazonSocial);
        }


        [Test]
        public void _03_TestInsertCreateNewRow()
        {

            var service = new ClienteService(entitiesMock.Object);

            service.Insert(new Cliente { DniRuc = "71621467", NombresRazonSocial = "Lorem ipsum" });
        }


        private IQueryable<Cliente> ClienteFakeDB()
        {
            return new List<Cliente>
            {
                new Cliente { Id = 1, DniRuc = "71621467", NombresRazonSocial = "Lorem ipsum"},
                new Cliente { Id = 2, DniRuc = "71621468", NombresRazonSocial = "Lorem ipsum"},

            }.AsQueryable();
        }
    }
}
