using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.TestContext;
using ProftaakProject.Models;
using ProftaakProject.Repositories;

namespace ProftaakTest
{
    [TestClass]
    public class EvenementTest
    {
        private IEventContext _context;
        private EvenementRepo _evRepo;

        [TestInitialize]
        public void TestInit()
        {
            _context = new TestEventContext();
            _evRepo = new EvenementRepo(_context);
        }

 
        [TestMethod]
        public void Should_Create_Evenement()
        {
           bool result = _evRepo.Create(new Evenement(18), 2);
           Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Return_Evenement()
        {
            Evenement e = _evRepo.Read(1);
            Assert.AreEqual("Test evenement 1", e.Naam);
        }

        [TestMethod]
        public void Should_Update_Evenement()
        {
            Evenement e = new Evenement(1)
            {
                Naam = "Testnaam",
                Locatie = "Testlocatie"
            };

            bool result = _evRepo.Update(e);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Delete_Evenement()
        {
            int id = 1;
            bool result = _evRepo.Delete(id);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Get_All_By_UserId()
        {
            int userid = 2;
            List<Evenement> evenementen = _evRepo.GetAllByUserId(userid);

            Assert.AreEqual(1, evenementen.Count);
        }
    }
}
