// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;

namespace StatusIo
{
    public class StatusIoConfiguration
    {
        public string ApiId { get; set; }
        public string ApiKey { get; set; }
        public string DefaultStatusPageId { get; set; }

        public Uri Endpoint { get; set; }
        public TimeSpan Timeout { get; set; }

        public bool ThrowOnError { get; set; }

        public StatusIoConfiguration()
        {
            ThrowOnError = false;
            Timeout = TimeSpan.FromSeconds(30);
            Endpoint = new Uri("https://api.status.io/v2/");
        }
    }
}