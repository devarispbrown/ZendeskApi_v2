﻿using Newtonsoft.Json;

namespace ZenDeskApi_v2.Models.Tickets
{

    public class SatisfactionRating
    {

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
