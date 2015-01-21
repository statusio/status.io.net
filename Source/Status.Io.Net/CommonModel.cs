// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace StatusIo
{
    [DebuggerDisplay("{Message}")]
    public class Status
    {
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public abstract class Response
    {
        public Status Status { get; set; }
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }

    [DebuggerDisplay("{DateTime}")]
    public class History
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "message_id")]
        public string MessageId { get; set; }

        public DateTime DateTime { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public abstract class Component
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public History[] History { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string StatusPage { get; set; }

        [JsonProperty(PropertyName = "hook_key")]
        public string HookKey { get; set; }
    }

    public class ComponentWithContainer : Component
    {
        public Container[] Containers { get; set; }
    }

    public class ComponentWithContainerIds : Component
    {
        [JsonProperty(PropertyName = "containers")]
        public string[] ContainerIds { get; set; }
    }

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

    public enum IncidentStatus
    {
        Operational = 100,
        DegradedPerformance = 300,
        PartialServiceDisruption = 400,
        ServiceDisruption = 500,
        SecurityEvent = 600
    }

    public enum IncidentState
    {
        Investigating = 100,
        Identified = 200,
        Monitoring = 300
    }
}