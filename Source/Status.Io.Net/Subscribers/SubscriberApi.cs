// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Subscribers
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
    }
}