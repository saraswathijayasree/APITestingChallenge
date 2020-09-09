using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace APITestingChallenge
{
    public partial class UserListJSonModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int Per_page { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int Total_pages { get; set; }
        
        [JsonProperty("data")]
        public List<User> Users { get; set; }

        [JsonProperty("ad")]
        public Ad Ad { get; set; }
    }
   


}
