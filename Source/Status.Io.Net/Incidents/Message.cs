// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    [DebuggerDisplay("{Details}")]
    public class MessageBase
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Details { get; set; }
        public string Source { get; set; }

        public OperationalState State { get; set; }

        [JsonProperty(PropertyName = "statuspage")]
        public string StatusPageId { get; set; }

        public string Ip { get; set; }
        public DateTime DateTime { get; set; }

        [JsonProperty(PropertyName = "containers")]
        public string[] ContainerIds { get; set; }

        [JsonProperty(PropertyName = "components")]
        public string[] ComponentIds { get; set; }
    }

    public class MaintenanceMessage : MessageBase
    {
        [JsonProperty(PropertyName = "maintenance")]
        public string MaintenanceId { get; set; }
    }

    public class Message : MessageBase
    {
        public IncidentStatus Status { get; set; }

        [JsonProperty(PropertyName = "incident")]
        public string IncidentId { get; set; }

        [JsonProperty(PropertyName = "user_email")]
        public string UserEmail { get; set; }

        [JsonProperty(PropertyName = "user_full_name")]
        public string UserFullName { get; set; }
    }
}