// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System.Threading.Tasks;

namespace StatusIo.Incidents
{
    public class IncidentApi
    {
        private readonly StatusIoClient client;

        internal IncidentApi(StatusIoClient client)
        {
            this.client = client;
        }

        private string DefaultStatusPageId { get { return client.Configuration.StatusPageId; } }

        public Task<Response<Incidents>> GetListAsync(string statusPageId = null)
        {
            return client.GetAsync<Response<Incidents>>("incident/list/" + (statusPageId ?? DefaultStatusPageId));
        }

        public Task<Response<Message>> GetMessageAsync(string messageId, string statusPageId = null)
        {
            return client.GetAsync<Response<Message>>("incident/message/" + 
                (statusPageId ?? DefaultStatusPageId) + "/" + messageId);
        }

        public Task<Response<string>> CreateAsync(CreateIncident incident)
        {
            incident.StatusPageId = incident.StatusPageId ?? DefaultStatusPageId;
            return client.PostAsync<Response<string>>("incident/create", incident);
        }

        public Task<Response<bool>> UpdateAsync(UpdateIncident incident)
        {
            incident.StatusPageId = incident.StatusPageId ?? DefaultStatusPageId;
            return client.PostAsync<Response<bool>>("incident/update", incident);
        }

        public Task<Response<string>> ResolveAsync(ResolveIncident incident)
        {
            incident.StatusPageId = incident.StatusPageId ?? DefaultStatusPageId;
            return client.PostAsync<Response<string>>("incident/resolve", incident);
        }

        public Task<Response<string>> DeleteAsync(string incidentId, string statusPageId = null)
        {
            return client.PostAsync<Response<string>>("incident/delete", new 
            {
                statuspage_id = statusPageId ?? DefaultStatusPageId,
                incident_id = incidentId
            });
        }
    }
}