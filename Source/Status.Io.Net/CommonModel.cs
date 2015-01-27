// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;
using Newtonsoft.Json;

namespace StatusIo
{
    [DebuggerDisplay("{Message}")]
    public class ResponseStatus
    {
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public abstract class Response
    {
        public ResponseStatus Status { get; set; }
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }

    public enum IncidentStatus
    {
        Operational = 100,
        DegradedPerformance = 300,
        PartialServiceDisruption = 400,
        ServiceDisruption = 500,
        SecurityEvent = 600
    }

    public enum OperationalState
    {
        Investigating = 100,
        Identified = 200,
        Monitoring = 300
    }

    public abstract class NotificationBase
    {
        [JsonProperty(PropertyName = "statuspage_id")]
        public string StatusPageId { get; set; }

        [JsonProperty(PropertyName = "notify_email")]
        public bool NotifyEmail { get; set; }

        [JsonProperty(PropertyName = "notify_sms")]
        public bool NotifySms { get; set; }

        [JsonProperty(PropertyName = "notify_webhook")]
        public bool NotifyWebhook { get; set; }

        [JsonProperty(PropertyName = "social")]
        public bool NotifySocial { get; set; }

        [JsonProperty(PropertyName = "irc")]
        public bool NotifyIrc { get; set; }

        [JsonProperty(PropertyName = "hipchat")]
        public bool NotifyHipchat { get; set; }

        [JsonProperty(PropertyName = "slack")]
        public bool NotifySlack { get; set; }
    }
}