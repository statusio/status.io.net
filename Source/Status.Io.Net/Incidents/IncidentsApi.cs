// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Incidents
{
    public class IncidentsApi
    {
        private readonly StatusIoClient client;

        internal IncidentsApi(StatusIoClient client)
        {
            this.client = client;
        }

        private string StatusPageId { get { return client.Configuration.StatusPageId; } }

        public Task<Response<Incidents>> GetListAsync()
        {
            return client.GetAsync<Response<Incidents>>("incident/list/" + StatusPageId);
        }

        public Task<Response<DisplayMessage>> GetMessageAsync(string messageId)
        {
            return client.GetAsync<Response<DisplayMessage>>("incident/message/" + StatusPageId + "/" + messageId);
        }

        public Task<Response<string>> CreateAsync(CreateIncident incident)
        {
            return client.PostAsync<Response<string>>("incident/create", incident);
        }

        public Task<Response<bool>> UpdateAsync(UpdateIncident incident)
        {
            return client.PostAsync<Response<bool>>("incident/update", incident);
        }

        public Task<Response<string>> ResolveAsync(ResolveIncident incident)
        {
            return client.PostAsync<Response<string>>("incident/resolve", incident);
        }

        public Task<Response<string>> DeleteAsync(string incidentId)
        {
            return client.PostAsync<Response<string>>("incident/delete", new 
            {
                statuspage_id = StatusPageId,
                incident_id = incidentId
            });
        }
    }
}