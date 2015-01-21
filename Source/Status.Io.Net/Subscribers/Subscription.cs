﻿// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Subscribers
{
    [DebuggerDisplay("{Address}")]
    public class Subscription
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Address { get; set; }

        [JsonProperty(PropertyName = "join_date")]
        public DateTime JoinDate { get; set; }

        [JsonProperty(PropertyName = "meth")]
        public string Method { get; set; }

        public bool Active { get; set; }

        [JsonProperty(PropertyName = "statuspage")]
        public string StatusPageId { get; set; }
    }
}