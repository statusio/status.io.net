// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    [DebuggerDisplay("Update incident {IncidentId} to {CurrentStatus}, {CurrentState}")]
    public class UpdateIncident : IncidentBase
    {
        [JsonProperty(PropertyName = "incident_id")]
        public string IncidentId { get; set; }

        [JsonProperty(PropertyName = "current_status")]
        public IncidentStatus CurrentStatus { get; set; }

        [JsonProperty(PropertyName = "current_state")]
        public OperationalState CurrentState { get; set; }
    }
}