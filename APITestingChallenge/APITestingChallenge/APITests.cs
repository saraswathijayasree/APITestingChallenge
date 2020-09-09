using APITestingChallenge.Helpers;
using APITestingChallenge.Model.JSonModel;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace APITestingChallenge
{

    public class Tests
    {

        /// <summary>
        /// 1.	Verify that a POST request can be posted to the API to create the single user and assert that the single user is created. 
        /// </summary>
        [Test]
        public void CreateNewUserTest()
        {
            //Arrange
            var url = "https://reqres.in/api/users";
            UserRequestJsonModel newUserData = new UserRequestJsonModel()
            {
                name = "morpheus",
                job = "developer"
            };

            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);
            RestRequest request = apiHelper.CreatePostRequest(newUserData);

            //Act
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<CreateUserResponseJSonModel>(response.Content.ToString());

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "New user creation Failed");
            Assert.IsTrue(((result.name == newUserData.name) && (result.job == newUserData.job)), "Created User is different");

        }

        /// <summary>
        /// 2.	Verify that a GET request can be posted to the API to get the expected details of single user
        /// </summary>
        [Test]
        public void VerifySingleUserDetailsTest()
        {
            //Arrange

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

            string url = "https://reqres.in/api/users/2";

            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);
            RestRequest request = apiHelper.CreateGetRequest();
           
            //Act
            IRestResponse response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<SingleUserJSonModel>(response.Content.ToString());

            // Assert
            Assert.IsTrue(DataHelper.CompareSingleUserData(expectedUserData, result.User) &&
                DataHelper.CompareUserAdData(expectedAdData, result.Ad), "Response Received is wrong");


        }


        /// <summary>
        /// 3.	Verify that a GET request can be posted to the API to get the expected details of the list of users
        /// </summary>
        [Test]
        public void VerifyUserListDetailsTest()
        {
            //Arrange
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

            string url = "https://reqres.in/api/users?page=2";
            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);
            RestRequest request = apiHelper.CreateGetRequest();

            //Act
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<UserListJSonModel>(response.Content.ToString());
            // assert
            Assert.IsTrue(DataHelper.CompareMultipleUserData(expectedUsersData, result.Users) &&
                DataHelper.CompareUserAdData(expectedAdData, result.Ad), "Response Received is wrong");
        }


        /// <summary>
        /// 4.	Verify that a PUT request can be posted to the API to update the single user and assert that the expected update was made. 
        /// </summary>
        [Test]
        public void VerifyUpdateUserTest()
        {
            //Arrange
            UserRequestJsonModel updatedUserData = new UserRequestJsonModel()
            {
                name = "morpheus",
                job = "tester"
            };

            var url = "https://reqres.in/api/users/2";

            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);           
            RestRequest request = apiHelper.CreatePutRequest(updatedUserData);

            //Act
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<UpdateResponseJsonModel>(response.Content.ToString());

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Update user Failed");
            Assert.IsTrue(((result.name == updatedUserData.name) && (result.job == updatedUserData.job)), "User not updated successfully");


        }


        /// <summary>
        /// 5.	Verify that a GET request can be posted to the API to return a single user not found, which should return a “404” response. 
        /// </summary>
        [Test]
        public void VerifyUserNotFoundTest()
        {
            //Arrange
            string url = "https://reqres.in/api/users/23";
            RestAPIHelpers apiHelper = new RestAPIHelpers();
            RestClient client = new RestClient(url);
            RestRequest request = apiHelper.CreateGetRequest();
          
            //Act
            IRestResponse response = client.Execute(request);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }


    }
}