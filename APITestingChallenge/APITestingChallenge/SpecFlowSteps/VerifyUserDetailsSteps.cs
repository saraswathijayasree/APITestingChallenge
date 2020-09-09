using APITestingChallenge.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace APITestingChallenge.SpecFlowSteps
{
    [Binding]
    public class VerifyUserDetailsSteps
    {
        public static IRestResponse response;
        string getDetailsUrl;

        [Given(@"I have the url ""(.*)""")]
        public void GivenIHaveTheUrl(string url)
        {
            getDetailsUrl = url;
        }

        [When(@"I submit GET user details request")]
        public void WhenISubmitGETUserDetailsRequest()
        {
            RestClient client = new RestClient(getDetailsUrl);
            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestRequest request = apiHelper.CreateGetRequest();

            response = client.Execute(request);
        }

        [Then(@"Compare the response with the expected result")]
        public void ThenCompareTheResponseWithTheExpectedResult()
        {
            User expectedUserData = new User()
            {
                Id = 2,
                Email = "janet.weaver@reqres.in",
                First_name = "Janet",
                Last_name = "Weaver",
                Avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"
            };

            Ad expectedAdData = new Ad()
            {
                Company = "StatusCode Weekly",
                Url = "http://statuscode.org/",
                Text = "A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things."
            };

            var result = JsonConvert.DeserializeObject<SingleUserJSonModel>(response.Content.ToString());
            // assert
            Assert.IsTrue(DataHelper.CompareSingleUserData(expectedUserData, result.User) &&
                DataHelper.CompareUserAdData(expectedAdData, result.Ad), "Response Received is wrong");
        }


        [Then(@"Compare the response details of users with the expected result")]
        public void ThenCompareTheResponseDetailsOfUsersWithTheExpectedResult()
        {
            List<User> expectedUsersData = new List<User>()
            {
                new User()
                {
                Id = 7,
                Email = "michael.lawson@reqres.in",
                First_name = "Michael",
                Last_name = "Lawson",
                Avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/follettkyle/128.jpg"
                },
                new User()
                {
                Id = 8,
                Email = "lindsay.ferguson@reqres.in",
                First_name = "Lindsay",
                Last_name = "Ferguson",
                Avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/araa3185/128.jpg"
                },
                new User()
                {
                Id = 9,
                Email ="tobias.funke@reqres.in",
                First_name = "Tobias",
                Last_name = "Funke",
                Avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/vivekprvr/128.jpg"
                },
                new User()
                {
                Id = 10,
                Email ="byron.fields@reqres.in",
                First_name = "Byron",
                Last_name = "Fields",
                Avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/russoedu/128.jpg"
                },
                new User()
                {
                Id =11,
                Email= "george.edwards@reqres.in",
                First_name= "George",
                Last_name= "Edwards",
                Avatar= "https://s3.amazonaws.com/uifaces/faces/twitter/mrmoiree/128.jpg"
                },
                new User()
                {
                Id= 12,
                Email= "rachel.howell@reqres.in",
                First_name= "Rachel",
                Last_name= "Howell",
                Avatar= "https://s3.amazonaws.com/uifaces/faces/twitter/hebertialmeida/128.jpg"
                }

            };

            Ad expectedAdData = new Ad()
            {
                Company = "StatusCode Weekly",
                Url = "http://statuscode.org/",
                Text = "A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things."
            };
            var result = JsonConvert.DeserializeObject<UserListJSonModel>(response.Content.ToString());

            Assert.IsTrue(DataHelper.CompareMultipleUserData(expectedUsersData, result.Users) &&
                DataHelper.CompareUserAdData(expectedAdData, result.Ad), "Response Received is wrong");
        }

    }
}
