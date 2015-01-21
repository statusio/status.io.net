// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    [DebuggerDisplay("{Name}")]
    public class Incident
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "components_affected")]
        public ComponentWithContainerIds[] ComponentsAffected { get; set; }

        [JsonProperty(PropertyName = "containers_affected")]
        public Container[] ContainersAffected { get; set; }

        [JsonProperty(PropertyName = "datetime_open")]
        public DateTime DateTimeOpen { get; set; }

        public string Kind { get; set; }
        public Message[] Messages { get; set; }

        [JsonProperty(PropertyName = "statuspage")]
        public string StatusPageId { get; set; }
    }
}