using System;
using System.Linq;
using System.Threading.Tasks;
using StatusIo.Components;
using StatusIo.Incidents;
using StatusIo.Subscribers;

namespace StatusIo.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            TestList();
            Console.ReadKey();
        }

        static async void TestList()
        {
            var configuration = new StatusIoConfiguration
            {
                StatusPageId = "54bee43fcdd613804f0004aa",
                Endpoint = new Uri("http://private-anon-e41b7bd6b-statusio.apiary-proxy.com/v2/"),
                ThrowOnError = true
            };

            var client = new StatusIoClient(configuration);

            await Test(client.Incidents);
            await Test(client.Components);
            await Test(client.Subscribers);
        }

        private static async Task Test(IncidentApi incidents)
        {
            var listIncidentBefore = await incidents.GetListAsync();
            var firstActiveMessage = listIncidentBefore.Result.Active.First().Messages.First();
            var getMessage = await incidents.GetMessageAsync(firstActiveMessage.Id);

            var newIncident = await incidents.CreateAsync(new CreateIncident
            {
                Name = "Test " + DateTime.Now,
                Details = "Automatically created.",
                CurrentStatus = IncidentStatus.PartialServiceDisruption,
                CurrentState = IncidentState.Investigating,
                ComponentIds = getMessage.Result.ComponentIds,
                ContainerIds = getMessage.Result.ContainerIds
            });

            var listIncidentAfter = await incidents.GetListAsync();
            var lastActiveIncident = listIncidentAfter.Result.Active.Last();

            var deleteIncident = await incidents.DeleteAsync(lastActiveIncident.Id);
        }

        private static async Task Test(ComponentApi components)
        {
            var listComponents = await components.GetListAsync();
        }

        private static async Task Test(SubscriberApi subscribers)
        {
            var listSubscribersBefore = await subscribers.GetListAsync();
            var damien = listSubscribersBefore.Result.Email.FirstOrDefault(s => s.Address == "damieng@gmail.com");

            if (damien != null)
            {
                var deleteSubscriber = await subscribers.DeleteAsync(damien.Id);
            }

            var addSubscriber = await subscribers.AddAsync("email", "damieng@gmail.com");
            var listSubscribersAfter = await subscribers.GetListAsync();

            foreach (var result in listSubscribersAfter.Result.Email)
                Console.WriteLine(result.Address + " joined " + result.JoinDate);
        }
    }
}