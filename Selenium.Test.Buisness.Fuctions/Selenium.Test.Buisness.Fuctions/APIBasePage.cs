using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Selenium.Test.Common.Function.PageFuctions;
using Selenium.Test.Common.Function.Reporting;
using System;
using System.ComponentModel;
using System.Net;
using System.Xml;

namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class APIBasePage
    {

        private static LoggerClass log = WebDriverBase.log;


        public RestClient restClient = null;
        public RestRequest restRequest = null;
        public IRestResponse restResponse = null;
        public string response;


        public void CreateRequest(string endpoint, string resource, Method httpmethod)
        {
            try
            {
                restClient = new RestClient(endpoint);
                restRequest = new RestRequest(resource, httpmethod);
                log.LogMessage("Created " + httpmethod + " request " + endpoint + resource);

            }
            catch (Exception ex)
            {
                log.LogError(ex, "Failed to create " + httpmethod + " request " + endpoint + resource);
            }

        }

        public void AddHeader(string headerName, string headerValue)
        {
            try
            {
                restRequest.AddHeader(headerName, headerValue);
                log.LogMessage(string.Format("Added '{0}' as HTTP header with value '{1}'", headerName, headerValue));

            }
            catch (Exception ex)
            {
                log.LogError(ex, string.Format("Failed to add '{0}' as HTTP header with value '{1}'", headerName, headerValue));
            }

        }

        public IRestResponse ExecuteRequest()
        {
            restResponse = restClient.Execute(restRequest);
            log.LogMessage(string.Format("Executed Rest request '{0}' returned status '{1}' and response equals '{2}'", restRequest.Resource, restResponse.StatusCode, response));
            return restResponse;

        }
        public void AddParameter(string parameterName, string parameterValue)
        {
            restRequest.AddParameter(parameterName, parameterValue);
        }

        public void AddParameter(string parameterName, JObject jobject, ParameterType parameter)
        {
            restRequest.AddParameter("application/json", jobject, parameter);
        }

        public string GetValueFromResponse(string newResponse, string responseValue)
        {
            string value;
            var jObject = JObject.Parse(newResponse);
            value = jObject.GetValue(responseValue).ToString();

            log.LogMessage(string.Format("Value '{0}' from response equals '{1}'", responseValue, value));
            return value;
        }

        public string ConvertXmlResponseToJson(string newResponce)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(newResponce);
            string jsonResponse = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
            return jsonResponse;
        }

        public void VerifyStatusCode(HttpStatusCode actualStatusCode, HttpStatusCode expectedStatusCode)
        {
            Assertions.AssertAreEqual(expectedStatusCode.ToString(), actualStatusCode.ToString(), "Status code did not match");
        }
        public void VerifyStatusCode(HttpStatusCode actualStatusCode, int expectedStatusCode)
        {
            int actualCode = (int)actualStatusCode;
            Assertions.AssertAreEqual(expectedStatusCode.ToString(), actualCode.ToString(), "Status code did not match");
        }

        public void VerifyResponseContains(string responseValue)
        {
            Assertions.AssetIsTrue(response.Contains(responseValue), "Response does not contain" + responseValue);
        }

        //public void LogResponse(string newResponse)
        //{
        //    dynamic content = JsonConvert.DeserializeObject(newResponse);

        //    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(content))
        //    {
        //        string name = descriptor.Name;
        //        object value = descriptor.GetValue(content);
        //        {
        //        }
        //        log.LogMessage(name + " = " + value);
        //    }
        //}

        public void LogResponseProperties(string content)
        {

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(content))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(content);
                log.LogMessage("Property '" + name + "' equals '" + value + "'");
            }
        }
        public IRestResponse ExecuteRequestToReturnRestResponse()
        {
            restResponse = restClient.Execute(restRequest);
            log.LogMessage("Request - " + restRequest + " Executed.");

            return restResponse;
        }
        public string ExecuteRequestWithResponse()
        {
            restResponse = restClient.Execute(restRequest);
            response = restResponse.Content;
            log.LogMessage(string.Format("Executed Rest request '{0}' returned status '{1}' and response equals '{2}'", restRequest.Resource, restResponse.StatusCode, response));
            return response;

        }

    }
}
