// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    [DebuggerDisplay("{Active.Length} active, {Resolved.Length} resolved")]
    public class Incidents
    {
        [JsonProperty(PropertyName = "active_incidents")]
        public Incident[] Active { get; set; }

        [JsonProperty(PropertyName = "resolved_incidents")]
        public Incident[] Resolved { get; set; }
    }
}