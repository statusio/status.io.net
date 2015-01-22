// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Components
{
    [DebuggerDisplay("{DateTime}")]
    public class History
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "message_id")]
        public string MessageId { get; set; }

        public DateTime DateTime { get; set; }
    }
}