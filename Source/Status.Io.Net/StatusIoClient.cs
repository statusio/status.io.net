// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using System.Threading.Tasks;
using StatusIo.Components;
using StatusIo.Incidents;
using StatusIo.Metrics;
using StatusIo.Status;
using StatusIo.Subscribers;

namespace StatusIo
{
    public class StatusIoClient : IDisposable
    {
        private readonly ComponentApi components;
        private readonly IncidentApi incidents;
        private readonly MetricApi metrics;
        private readonly StatusApi status;
        private readonly SubscriberApi subscribers;

        private StatusIoNetwork network;

        public StatusIoClient(StatusIoConfiguration configuration)
        {
            Configuration = configuration;
            network = new StatusIoNetwork(configuration);

            components = new ComponentApi(this);
            incidents = new IncidentApi(this);
            metrics = new MetricApi(this);
            status = new StatusApi(this);
            subscribers = new SubscriberApi(this);           
        }

        public ComponentApi Components { get { return components; } }
        public IncidentApi Incidents { get { return incidents; } }
        public MetricApi Metrics { get { return metrics; } }
        public StatusApi Status { get {  return status; } }
        public SubscriberApi Subscribers { get { return subscribers; } }

        internal readonly StatusIoConfiguration Configuration;

        internal string GetStatusPageId(string statusPageId)
        {
            return CleanAndValidateId(statusPageId ?? Configuration.DefaultStatusPageId);
        }

        internal string CleanAndValidateId(string id)
        {
            var clean = id.Trim().ToLowerInvariant();
            for (int i = 0; i < clean.Length; i++)
                if (clean[i] < '0' || clean[i] > 'f')
                    throw new StatusIoErrorException(string.Format("id {0} must be hexadecimal chars 0-f only", id));

            return clean;
        }

        internal Task<T> GetAsync<T>(string path) where T : Response
        {
            return network.SendRequestAsync<T>("GET", path, null);
        }

        internal Task<T> PostAsync<T>(string path, object body) where T : Response
        {
            return network.SendRequestAsync<T>("POST", path, body);
        }

        internal Task<T> PatchAsync<T>(string path, object body) where T : Response
        {
            return network.SendRequestAsync<T>("PATCH", path, body);
        }

        internal Task<T> DeleteAsync<T>(string path) where T : Response
        {
            return network.SendRequestAsync<T>("DELETE", path, null);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || network == null) return;
            network.Dispose();
            network = null;
        }
    }
}