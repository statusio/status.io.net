// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using Newtonsoft.Json;

namespace StatusIo.Incidents
{
    public abstract class IncidentBase
    {
        [JsonProperty(PropertyName = "statuspage_id")]
        public string StatusPageId { get; set; }

        [JsonProperty(PropertyName = "incident_details")]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "notify_email")]
        public int NotifyEmail { get; set; }

        [JsonProperty(PropertyName = "notify_sms")]
        public int NotifySms { get; set; }

        [JsonProperty(PropertyName = "notify_webhook")]
        public int NotifyWebhook { get; set; }

        [JsonProperty(PropertyName = "social")]
        public int NotifySocial { get; set; }

        [JsonProperty(PropertyName = "irc")]
        public int NotifyIrc { get; set; }

        [JsonProperty(PropertyName = "hipchat")]
        public int NotifyHipchat { get; set; }

        [JsonProperty(PropertyName = "slack")]
        public int NotifySlack { get; set; }
    }
}
