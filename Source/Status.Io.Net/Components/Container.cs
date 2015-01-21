// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Components
{
    [DebuggerDisplay("{Name}")]
    public class Container
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        [JsonProperty(PropertyName = "location_geo")]
        public GeoLocation LocationGeo { get; set; }
    }
}