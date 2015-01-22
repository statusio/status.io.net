// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    [DebuggerDisplay("Resolve incident {IncidentId}")]
    public class ResolveIncident : IncidentBase
    {
        [JsonProperty(PropertyName = "incident_id")]
        public string IncidentId { get; set; }
    }
}