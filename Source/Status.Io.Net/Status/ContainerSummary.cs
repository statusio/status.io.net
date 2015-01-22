﻿// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;

namespace StatusIo.Status
{
    [DebuggerDisplay("{Name} is {Status}")]
    public class ContainerSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }
        public OperationalState State { get; set; }
    }
}