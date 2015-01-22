// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Incidents
{
    public class IncidentApi
    {
        private readonly StatusIoClient client;

        public IncidentApi(StatusIoClient client)
        {
            this.client = client;
        }

        public Task<Response<Incidents>> GetListAsync(string statusPageId = null)
        {
            return client.GetAsync<Response<Incidents>>(
                "incident/list/" + client.GetStatusPageId(statusPageId));
        }

        public Task<Response<Message>> GetMessageAsync(string messageId, string statusPageId = null)
        {
            return client.GetAsync<Response<Message>>(
                "incident/message/" + client.GetStatusPageId(statusPageId) + "/" + messageId);
        }

        public Task<Response<string>> CreateAsync(CreateIncident incident)
        {
            incident.StatusPageId = client.GetStatusPageId(incident.StatusPageId);
            return client.PostAsync<Response<string>>("incident/create", incident);
        }

        public Task<Response<bool>> UpdateAsync(UpdateIncident incident)
        {
            incident.StatusPageId = client.GetStatusPageId(incident.StatusPageId);
            return client.PostAsync<Response<bool>>("incident/update", incident);
        }

        public Task<Response<string>> ResolveAsync(ResolveIncident incident)
        {
            incident.StatusPageId = client.GetStatusPageId(incident.StatusPageId);
            return client.PostAsync<Response<string>>("incident/resolve", incident);
        }

        public Task<Response<string>> DeleteAsync(string incidentId, string statusPageId = null)
        {
            return client.PostAsync<Response<string>>("incident/delete", new 
            {
                statuspage_id = client.GetStatusPageId(statusPageId),
                incident_id = incidentId
            });
        }
    }
}