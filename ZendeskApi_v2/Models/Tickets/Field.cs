﻿using Newtonsoft.Json;

namespace ZenDeskApi_v2.Models.Tickets
{

    public class Field
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
