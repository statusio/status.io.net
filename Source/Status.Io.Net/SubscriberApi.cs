// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StatusIo
{
    public class SubscriberApi
    {
        private readonly StatusIoClient client;

        internal SubscriberApi(StatusIoClient client)
        {
            this.client = client;
        }

        private string StatusPageId { get { return client.Configuration.StatusPageId; } }

        public Task<Response<Subscriptions>> GetListAsync()
        {
            return client.GetAsync<Response<Subscriptions>>("subscriber/list/" + StatusPageId);
        }

        public Task<Response<bool>> AddAsync(string method, string address, bool silent = false)
        {
            return client.PostAsync<Response<bool>>("subscriber/add", new
            {
                statuspage_id = StatusPageId,
                meth = method,
                address,
                silent = silent ? 1 : 0
            });
        }

        public Task<Response<Subscription>> UpdateAsync(string subscriberId, string address)
        {
            return client.PatchAsync<Response<Subscription>>("subscriber/update", new
            {
                statuspage_id = StatusPageId,
                subscriber_id = subscriberId,
                address,
            });
        }

        public Task<Response<bool>> DeleteAsync(string subscriberId)
        {
            return client.DeleteAsync<Response<bool>>("subscriber/remove/" + StatusPageId + "/" + subscriberId);
        }

        [DebuggerDisplay("{Address}")]
        public class Subscription
        {
            [JsonProperty(PropertyName = "join_date")]
            public DateTime JoinDate { get; set; }

            [JsonProperty(PropertyName = "_id")]
            public string Id { get; set; }

            [JsonProperty(PropertyName = "meth")]
            public string Method { get; set; }

            public bool Active { get; set; }
            public string Address { get; set; }
            public string StatusPage { get; set; }
        }

        public class Subscriptions
        {
            public Subscription[] Email { get; set; }
            public Subscription[] Webhook { get; set; }
            public Subscription[] Sms { get; set; }
        }
    }
}