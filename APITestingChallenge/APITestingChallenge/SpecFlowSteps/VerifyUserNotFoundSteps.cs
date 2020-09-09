using APITestingChallenge.Helpers;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace APITestingChallenge.SpecFlowSteps
{
    [Binding]
    public class VerifyUserNotFoundSteps
    {
        private IRestResponse response;
        string invalidUrl;

        [Given(@"I have the invalid url ""(.*)""")]
        public void GivenIHaveTheInvalidUrl(string url)
        {
            invalidUrl = url;
        }
        
        [When(@"I submit the GET request")]
        public void WhenISubmitTheGETRequest()
        {
            RestClient client = new RestClient(invalidUrl);            
            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestRequest request = apiHelper.CreateGetRequest();
            response = client.Execute(request);
        }

        [Then(@"verify the response is (.*)")]
        public void ThenVerifyTheResponseIs(int code)
        {
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }
    }
}
