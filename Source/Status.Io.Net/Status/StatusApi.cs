// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Status
{
    public class StatusApi
    {
        private readonly StatusIoClient client;

        internal StatusApi(StatusIoClient client)
        {
            this.client = client;
        }

        public Task<Response<ComponentSummary[]>> GetSummary(string statusPageId = null)
        {
            return client.GetAsync<Response<ComponentSummary[]>>(
                "stats/summary/" + client.GetStatusPageId(statusPageId));
        }
    }
}