// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    public class UpdateIncident : IncidentBase
    {
        [JsonProperty(PropertyName = "incident_id")]
        public string IncidentId { get; set; }

        [JsonProperty(PropertyName = "current_status")]
        public IncidentStatus CurrentStatus { get; set; }

        [JsonProperty(PropertyName = "current_state")]
        public IncidentState CurrentState { get; set; }
    }
}