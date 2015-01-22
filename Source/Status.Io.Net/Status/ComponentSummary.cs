// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;

namespace StatusIo.Status
{
    [DebuggerDisplay("{Name}")]
    public class ComponentSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ContainerSummary[] Containers { get; set; }
    }
}