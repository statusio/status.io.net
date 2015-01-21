// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    [DebuggerDisplay("{Details}")]
    public class Message
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Details { get; set; }
        public string Source { get; set; }

        public IncidentState State { get; set; }
        public IncidentStatus Status { get; set; }

        [JsonProperty(PropertyName = "statuspage")]
        public string StatusPageId { get; set; }

        public string Ip { get; set; }
        public DateTime DateTime { get; set; }

        [JsonProperty(PropertyName = "containers")]
        public string[] ContainerIds { get; set; }

        [JsonProperty(PropertyName = "components")]
        public string[] ComponentIds { get; set; }
    }
}