// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StatusIo
{
    public class Subscribers
    {
        private readonly StatusIoClient client;

        public Subscribers(StatusIoClient client)
        {
            this.client = client;
        }

        private string StatusPageId { get { return client.Configuration.StatusPageId; } }

        public Task<Response<ListResult>> GetListAsync()
        {
            return client.GetAsync<Response<ListResult>>("subscriber/list/" + StatusPageId);
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

        public Task<Response<Subscription>> DeleteAsync(string subscriberId)
        {
            return client.DeleteAsync<Response<Subscription>>("subscriber/remove/ " + StatusPageId + "/" + subscriberId);
        }

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

        public class ListResult
        {
            public Subscription[] Email { get; set; }
            public Subscription[] Webhook { get; set; }
            public Subscription[] SMS { get; set; }
        }
    }
}