// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Components
{
    public class ComponentApi
    {
        private readonly StatusIoClient client;

        public ComponentApi(StatusIoClient client)
        {
            this.client = client;
        }

        public Task<Response<ComponentWithContainer[]>> GetListAsync(string statusPageId = null)
        {
            return client.GetAsync<Response<ComponentWithContainer[]>>(
                "component/list/" + client.GetStatusPageId(statusPageId));
        }

        public Task<Response<bool>> UpdateAsync(string details, IncidentStatus status, string[] componentIds, string[] containerIds, string statusPageId = null)
        {
            return client.PostAsync<Response<bool>>("component/status/update", new
            {
                statuspage_id = client.GetStatusPageId(statusPageId),
                details,
                components = componentIds,
                containers = containerIds,
                current_status = status,
            });
        }
    }
}