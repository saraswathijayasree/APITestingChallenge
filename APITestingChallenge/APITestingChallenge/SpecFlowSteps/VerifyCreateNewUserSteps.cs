using APITestingChallenge.Helpers;
using APITestingChallenge.Model.JSonModel;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace APITestingChallenge.SpecFlowSteps
{
    [Binding]
    public class VerifyCreateNewUserSteps
    {
        private IRestResponse response;
        string url = "https://reqres.in/api/users";
        UserRequestJsonModel newUserData = new UserRequestJsonModel();


        [Given(@"I input the name ""(.*)""")]
        public void GivenIInputTheName(string name)
        {
            newUserData.name = name;
        }
        
        [Given(@"I input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            newUserData.job = role;
        }
        
        [When(@"I Post Create User request")]
        public void WhenIPostCreateUserRequest()
        {
            
            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);
            RestRequest request = apiHelper.CreatePostRequest(newUserData);

            response = client.Execute(request);
        }
        
        [Then(@"verfy that the user is created successfully")]
        public void ThenVerfyThatTheUserIsCreatedSuccessfully()
        {
            var result = JsonConvert.DeserializeObject<CreateUserResponseJSonModel>(response.Content.ToString());
            
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "New user creation Failed");
            Assert.IsTrue(((result.name == newUserData.name) && (result.job == newUserData.job)), "Created User is different");
        }
    }
}
