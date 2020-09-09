using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace APITestingChallenge
{
    public partial class Ad
    {

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

    }
}
