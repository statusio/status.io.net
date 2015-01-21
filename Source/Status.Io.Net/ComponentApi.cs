// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo
{
    public class ComponentApi
    {
        private readonly StatusIoClient client;

        internal ComponentApi(StatusIoClient client)
        {
            this.client = client;
        }

        private string StatusPageId { get { return client.Configuration.StatusPageId; } }

        public Task<Response<ComponentWithContainer[]>> GetListAsync()
        {
            return client.GetAsync<Response<ComponentWithContainer[]>>("component/list/" + StatusPageId);
        }

        public Task<Response<bool>> UpdateAsync(string details, IncidentStatus status, string[] components, string[] containers)
        {
            return client.PostAsync<Response<bool>>("component/status/update", new
            {
                statuspage_id = StatusPageId,
                details,
                components,
                containers,
                current_status = status,
            });
        }
    }
}