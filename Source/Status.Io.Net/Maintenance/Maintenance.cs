// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using Newtonsoft.Json;

namespace StatusIo.Maintenance
{
    public class Maintenance : NotificationBase
    {
        [JsonProperty(PropertyName = "maintenance_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "maintenance_details")]
        public string Details { get; set; }
    }
}