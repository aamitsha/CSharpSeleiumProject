using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Selenium.Test.Buisness.Fuctions.BuisnessFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Buisness.Fuctions.TestCases
{
    [TestClass]
    public class APITestClass : TestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            APIBaseTestInitialize();
        }

        [TestMethod]
        [TestCategory("API Test")]
        public void GetListOfAllTheUsers()
        {
            string request = "/api/users";
            RqRes_API rqres = new RqRes_API();
            rqres.GetListOfUsers(request, Method.GET, HttpStatusCode.OK);
        }
        [TestMethod]
        [TestCategory("API Test")]
        public void VerifySingleUser()
        {
            string request = "/api/users";
            RqRes_API rqres = new RqRes_API();
            rqres.GetSingleUser(request, Method.GET, "Janet");


        }
        [TestMethod]
        [TestCategory("API Test")]
        public void CreateUser()
        {
            string request = "/api/users";
            RqRes_API rqres = new RqRes_API();
            rqres.CreateUser(request, Method.POST, HttpStatusCode.OK);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            APIBaseTestCleanup();
        }


    }
}
