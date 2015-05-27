﻿// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using System.Diagnostics;
using System.Linq;
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

        [JsonProperty(PropertyName = "granular")]
        private string[] Granular
        {
            get { return Grains != null ? Grains.Select(g => g.ComponentId + "_" + g.ContainerId).ToArray() : new string[0]; }
            set
            {
                Grains = value.Select(g => new Grain
                {
                    ComponentId = g.Split('_')[0],
                    ContainerId = g.Split('_')[1]
                }).ToArray();
            }
        }

        [JsonIgnore]
        public Grain[] Grains { get; set; }
    }
}
