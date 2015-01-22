// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StatusIo
{
    internal class StatusIoNetwork : IDisposable
    {
        private readonly StatusIoConfiguration configuration;
        private HttpClient httpClient;

        public StatusIoNetwork(StatusIoConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient { Timeout = configuration.Timeout };

            SetHeaders(httpClient.DefaultRequestHeaders);
        }

        internal async Task<T> SendRequestAsync<T>(string method, string path, object body) where T : Response
        {
            EnsureNotDisposed();

            using (var requestMessage = new HttpRequestMessage(new HttpMethod(method), MakeUri(path)))
            {
                if (body != null)
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body, Formatting.Indented), Encoding.UTF8, "application/json");

                using (var responseMessage = await httpClient.SendAsync(requestMessage))
                {
                    responseMessage.EnsureSuccessStatusCode();
                    var response = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());

                    EnsureSuccessStatus(response.Status);
                    return response;
                }
            }
        }

        private void EnsureNotDisposed()
        {
            if (httpClient == null)
                throw new ObjectDisposedException("This StatusIoClient has been disposed. Either create a new instance or do not dispose of it if you wish to continue to use it.");
        }

        private void EnsureSuccessStatus(ResponseStatus status)
        {
            if (configuration.ThrowOnError && "yes".Equals(status.Error, StringComparison.OrdinalIgnoreCase))
                throw new StatusIoErrorException(status.Message);
        }

        private Uri MakeUri(string path)
        {
            var builder = new UriBuilder(configuration.Endpoint);
            builder.Path += path;
            return builder.Uri;
        }

        private void SetHeaders(HttpRequestHeaders headers)
        {
            headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            headers.Add("x-api-id", configuration.ApiId);
            headers.Add("x-api-key", configuration.ApiKey);
            headers.ExpectContinue = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || httpClient == null) return;
            httpClient.Dispose();
            httpClient = null;
        }
    }
}