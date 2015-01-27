// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Maintenance
{
    [DebuggerDisplay("{Active.Length} active, {Upcoming.Length} upcoming, {Resolved.Length} resolved")]
    public class MaintenanceList
    {
        [JsonProperty(PropertyName = "active_maintenances")]
        public MaintenanceInfo[] Active { get; set; }

        [JsonProperty(PropertyName = "upcoming_maintenances")]
        public MaintenanceInfo[] Upcoming { get; set; }

        [JsonProperty(PropertyName = "resolved_maintenances")]
        public MaintenanceInfo[] Resolved { get; set; }
    }
}
