// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    public class CreateIncident : IncidentBase
    {
        [JsonProperty(PropertyName = "incident_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "current_status")]
        public IncidentStatus CurrentStatus { get; set; }

        [JsonProperty(PropertyName = "current_state")]
        public IncidentState CurrentState { get; set; }

        [JsonProperty(PropertyName = "all_infrastructure_affected")]
        public int AllInfrastructureAffected { get; set; }

        [JsonProperty(PropertyName = "components")]
        public string[] ComponentIds { get; set; }

        [JsonProperty(PropertyName = "containers")]
        public string[] ContainerIds { get; set; }
    }
}
