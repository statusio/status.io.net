// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;
using StatusIo.Components;
using StatusIo.Incidents;

namespace StatusIo.Maintenance
{
    [DebuggerDisplay("{Name}")]
    public class MaintenanceInfo
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "components_affected")]
        public ComponentWithContainerIds[] ComponentsAffected { get; set; }

        [JsonProperty(PropertyName = "containers_affected")]
        public Container[] ContainersAffected { get; set; }

        [JsonProperty(PropertyName = "datetime_open")]
        public DateTime OpenAt { get; set; }

        [JsonProperty(PropertyName = "datetime_planned_start")]
        public DateTime PlannedStart { get; set; }

        [JsonProperty(PropertyName = "datetime_planned_end")]
        public DateTime PlannedEnd { get; set; }

        public string Kind { get; set; }
        public Message[] Messages { get; set; }

        [JsonProperty(PropertyName = "statuspage")]
        public string StatusPageId { get; set; }
    }
}