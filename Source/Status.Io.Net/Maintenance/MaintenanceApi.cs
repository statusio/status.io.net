// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Maintenance
{
    public class MaintenanceApi
    {
        private readonly StatusIoClient client;

        internal MaintenanceApi(StatusIoClient client)
        {
            this.client = client;
        }

        public Task<Response<MaintenanceList>> GetList(string statusPageId = null)
        {
            return client.GetAsync<Response<MaintenanceList>>(
                "maintenance/list/" + client.GetStatusPageId(statusPageId));
        }
    }
}