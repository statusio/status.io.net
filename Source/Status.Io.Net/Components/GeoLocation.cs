// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Components
{
    [DebuggerDisplay("{Name}")]
    public class GeoLocation
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public string Host { get; set; }

        public decimal?[] Coords { get; set; }

        [JsonProperty(PropertyName = "query_type")]
        public string QueryType { get; set; }
    }
}