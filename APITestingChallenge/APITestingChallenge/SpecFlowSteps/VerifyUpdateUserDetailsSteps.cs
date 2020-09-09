using APITestingChallenge.Helpers;
using APITestingChallenge.Model.JSonModel;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace APITestingChallenge.SpecFlowSteps
{
    [Binding]
    public class VerifyUpdateUserDetailsSteps
    {
        private IRestResponse response;
        string url = "https://reqres.in/api/users/2";
        UserRequestJsonModel updatedUserData = new UserRequestJsonModel();

        [Given(@"I input the name as ""(.*)""")]
        public void GivenIInputTheNameAs(string name)
        {
            updatedUserData.name = name;
        }
        
        [Given(@"I input job ""(.*)""")]
        public void GivenIInputJob(string role)
        {
            updatedUserData.job = role;
        }
        
        [When(@"I PUT request to update a user detail")]
        public void WhenIPUTRequestToUpdateAUserDetail()
        {
            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);
            RestRequest request = apiHelper.CreatePutRequest(updatedUserData);

            response = client.Execute(request);
        }
        
    
        [Then(@"Verify the status code and check updated details")]
        public void ThenVerifyTheStatusCodeAndCheckUpdatedDetails()
        {
            var result = JsonConvert.DeserializeObject<UpdateResponseJsonModel>(response.Content.ToString());

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Update user Failed");
            Assert.IsTrue(((result.name == updatedUserData.name) && (result.job == updatedUserData.job)), "User not updated successfully");

        }

    }
}
