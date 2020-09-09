using System;
using System.Collections;
using System.Text;
using Newtonsoft.Json;


namespace APITestingChallenge
{
    public partial class User
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string First_name { get; set; }

        [JsonProperty("last_name")]
        public string Last_name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

    }
}
