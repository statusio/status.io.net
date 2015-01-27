// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;

namespace StatusIo.Maintenance
{
    public class MaintenanceSchedule
    {
        public string StatusPageId { get; set; }

        public string[] ComponentIds { get; set; }
        public string[] ContainerIds { get; set; }

        public bool AllInfrastructureAffected { get; set; }

        public string Name { get; set; }
        public string Details { get; set; }

        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }

        public bool NotifyNow { get; set; }
        public bool Notify24h { get; set; }
        public bool Notify1h { get; set; }
    }
}