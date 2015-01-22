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
        public string NotifyEmail { get; set; }

        [JsonProperty(PropertyName = "notify_sms")]
        public string NotifySms { get; set; }

        [JsonProperty(PropertyName = "notify_webhook")]
        public string NotifyWebhook { get; set; }

        [JsonProperty(PropertyName = "social")]
        public string NotifySocial { get; set; }

        [JsonProperty(PropertyName = "irc")]
        public string NotifyIrc { get; set; }

        [JsonProperty(PropertyName = "hipchat")]
        public string NotifyHipchat { get; set; }

        [JsonProperty(PropertyName = "slack")]
        public string NotifySlack { get; set; }
    }
}
