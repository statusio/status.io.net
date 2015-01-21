// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo.Components
{
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
}