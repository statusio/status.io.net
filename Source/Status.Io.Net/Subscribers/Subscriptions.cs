// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;

namespace StatusIo.Subscribers
{
    [DebuggerDisplay("{Email.Length} Email, {Webhook.Length} Webhook, {Sms.Length} SMS")]
    public class Subscriptions
    {
        public Subscription[] Email { get; set; }
        public Subscription[] Webhook { get; set; }
        public Subscription[] Sms { get; set; }
    }
}