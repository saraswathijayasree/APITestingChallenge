using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace APITestingChallenge
{
    public partial class SingleUserJSonModel
    {
       
        [JsonProperty("data")]
        public User User { get; set; }

        [JsonProperty("ad")]
        public Ad Ad { get; set; }
    }
   


}
