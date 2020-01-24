using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProftaakProject.Models.ViewModels.AccountModels;
using System.Collections.Generic;
using ProftaakProject.Repositories;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.TestContext;
using ProftaakProject.Models;

namespace ProftaakTest
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void TestLogin()
        {
            //Arrange

            IAccountContext _Iac = new TestAccountContext();
            //AccountRepo _ar = new AccountRepo(_Iac);

            //Act

            //Assert
            //Assert.IsTrue();
        }
        [TestMethod]
        public void TestRegister()
        {
            //Arrange

            IAccountContext _Iac = new TestAccountContext();
            //AccountRepo _ar = new AccountRepo(_Iac);
            //Act
            //Assert
            //Assert.IsTrue();
        }
    }
}
