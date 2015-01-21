// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatusIo.Incidents;

namespace StatusIo
{
    public class StatusIoClient : IDisposable
    {
        internal readonly StatusIoConfiguration Configuration;
        private readonly ComponentApi components;
        private readonly IncidentsApi incidents;
        private readonly SubscriberApi subscribers;

        private HttpClient httpClient;

        public StatusIoClient(StatusIoConfiguration configuration)
        {
            Configuration = configuration;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-api-id", configuration.ApiId);
            httpClient.DefaultRequestHeaders.Add("x-api-key", configuration.ApiKey);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            components = new ComponentApi(this);
            incidents = new IncidentsApi(this);
            subscribers = new SubscriberApi(this);
        }

        public ComponentApi Components { get { return components; } }
        public IncidentsApi Incidents { get { return incidents; } }
        public SubscriberApi Subscribers { get { return subscribers; } }

        private Uri MakeUri(string path)
        {
            var builder = new UriBuilder(Configuration.Endpoint);
            builder.Path += path;
            return builder.Uri;
        }

        internal Task<T> GetAsync<T>(string path) where T : Response
        {
            return SendRequestAsync<T>("GET", path, null);
        }

        internal Task<T> PostAsync<T>(string path, object body) where T : Response
        {
            return SendRequestAsync<T>("POST", path, body);
        }

        internal Task<T> PatchAsync<T>(string path, object body) where T : Response
        {
            return SendRequestAsync<T>("PATCH", path, body);
        }

        internal Task<T> DeleteAsync<T>(string path) where T : Response
        {
            return SendRequestAsync<T>("DELETE", path, null);
        }

        private async Task<T> SendRequestAsync<T>(string method, string path, object body) where T : Response
        {
            CheckNotDisposed();

            using (var requestMessage = new HttpRequestMessage(new HttpMethod(method), MakeUri(path)))
            {
                if (body != null)
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body, Formatting.Indented), Encoding.UTF8, "application/json");

                using (var responseMessage = await httpClient.SendAsync(requestMessage))
                {
                    responseMessage.EnsureSuccessStatusCode();
                    var response = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());

                    if (Configuration.ThrowOnError && "yes".Equals(response.Status.Error, StringComparison.OrdinalIgnoreCase))
                        throw new StatusIoErrorException(response.Status.Message);

                    return response;
                }
            }
        }

        private void CheckNotDisposed()
        {
            if (httpClient == null)
                throw new ObjectDisposedException("This StatusIoClient has been disposed. Either create a new instance or do not dispose of it if you wish to continue to use it.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && httpClient != null)
            {
                httpClient.Dispose();
                httpClient = null;
            }
        }
    }
}