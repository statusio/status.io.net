// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

namespace StatusIo.Subscribers
{
    public class Grain
    {
        public string ComponentId { get; set; }
        public string ContainerId { get; set; }

        public string ToApiString()
        {
            return ComponentId + "_" + ContainerId;
        }
    }
}