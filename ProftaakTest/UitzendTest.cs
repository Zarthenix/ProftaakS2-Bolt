using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.TestContext;
using ProftaakProject.Models;
using ProftaakProject.Models.Repositories;

namespace ProftaakTest
{
    [TestClass]
    public class UitzendTest
    {
        private IUitzendContext _context;
        private UitzendRepo _repo;

        [TestInitialize]
        public void TestInit()
        {
            _context = new TestUitzendContext();
            _repo = new UitzendRepo(_context);
        }

        [TestMethod]
        public void Should_Create_Uitzendbureau()
        {
            Uitzendbureau bureau = new Uitzendbureau(5, "Test", 1);
            bool result = _repo.Create(bureau);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Update_Uitzendbureau()
        {
            Uitzendbureau bureau = new Uitzendbureau(1, "Testbureau", 1);
            bool result = _repo.Update(bureau);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Delete_Uitzendbureau()
        {
            int id = 1;
            bool result = _repo.Delete(id);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Get_All()
        {
            List<Uitzendbureau> bureaus = _repo.GetAll();
            Assert.AreEqual(3, bureaus.Count);
        }

        [TestMethod]
        public void Should_Get_By_Id()
        {
            int id = 1;
            Uitzendbureau bureau = _repo.GetByID(id);
            Assert.AreEqual("Easyflex", bureau.Naam);
        }
    }
}
