// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    public abstract class IncidentBase : NotificationBase
    {
        [JsonProperty(PropertyName = "incident_details")]
        public string Details { get; set; }
    }
}
