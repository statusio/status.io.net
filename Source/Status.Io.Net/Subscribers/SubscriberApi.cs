// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Linq;
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

        public Task<Response<Subscriptions>> GetListAsync(string statusPageId = null)
        {
            return client.GetAsync<Response<Subscriptions>>(
                "subscriber/list/" + client.GetStatusPageId(statusPageId));
        }

        public Task<Response<bool>> AddAsync(string method, string address, string statusPageId = null, bool silent = false, Grain[] granular = null)
        {
            return client.PostAsync<Response<bool>>("subscriber/add", new
            {
                statuspage_id = client.GetStatusPageId(statusPageId),
                meth = method,
                address,
                silent = silent ? "1" : "0",
                granular = granular != null ? string.Join(",", granular.Select(g => g.ToApiString())) : null
            });
        }

        public Task<Response<Subscription>> UpdateAsync(string subscriberId, string address, string statusPageId = null, Grain[] granular = null)
        {
            return client.PatchAsync<Response<Subscription>>("subscriber/update", new
            {
                statuspage_id = client.GetStatusPageId(statusPageId),
                subscriber_id = subscriberId,
                address,
                granular = granular != null ? string.Join(",", granular.Select(g => g.ToApiString())) : null
            });
        }

        public Task<Response<bool>> DeleteAsync(string subscriberId, string statusPageId = null)
        {
            return client.DeleteAsync<Response<bool>>(
                "subscriber/remove/" + client.GetStatusPageId(statusPageId) + "/" + subscriberId);
        }
    }
}