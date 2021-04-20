using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class RqRes_API : APIBasePage
    {
        private string endPoint = "https://reqres.in/";
        public RqRes_API GetListOfUsers(string resource, Method methodName, HttpStatusCode code)
        {
            CreateRequest(endPoint, resource, methodName);
            AddParameter("page", "2");
            IRestResponse response = ExecuteRequest();
            VerifyStatusCode(response.StatusCode, HttpStatusCode.OK);
            return this;
        }
        public RqRes_API CreateUser(string resource, Method methodName, HttpStatusCode code)
        {
            CreateRequest(endPoint, resource, methodName);
            AddParameter("name", "morpheus");
            AddParameter("job", "leader");
            IRestResponse response = ExecuteRequest();
            VerifyStatusCode(response.StatusCode, code);
            return this;
        }
        public RqRes_API GetSingleUser(string resource, Method methodName, string user)
        {
            CreateRequest(endPoint, resource, methodName);
            IRestResponse response = ExecuteRequest();
            VerifyStatusCode(response.StatusCode, HttpStatusCode.OK);
            return this;
        }

    }
}
