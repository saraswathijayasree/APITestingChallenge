using Newtonsoft.Json;
using RestSharp;

namespace APITestingChallenge.Helpers
{
    class RestAPIHelpers
    {

        /// <summary>
        /// Function to Create a GET request
        /// </summary>
        /// <returns>RestRequest</returns>
        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            return restRequest;
        }


        /// <summary>
        /// Function to Create a POST request
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>RestRequest</returns>
        public RestRequest CreatePostRequest(dynamic payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            return restRequest;
        }

        /// <summary>
        /// Function to Create a PUT request
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>RestRequest</returns>
        public RestRequest CreatePutRequest(dynamic payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            return restRequest;
        }
    }
}
