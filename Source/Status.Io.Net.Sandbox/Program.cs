using System;
using System.Linq;
using System.Threading.Tasks;
using StatusIo.Components;
using StatusIo.Incidents;
using StatusIo.Maintenance;
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
                // Put in your ApiId, ApiKey and DefaultStatusPageId here
                ThrowOnError = true
            };

            var client = new StatusIoClient(configuration);

            //await Test(client.Maintenance);
            //await Test(client.Incidents);
            //await Test(client.Components);
            //await Test(client.Subscribers);
        }

        private static async Task Test(MaintenanceApi maintenance)
        {
            var listMaintenance = await maintenance.GetList();

            Console.WriteLine("Active maintenance");
            foreach (var m in listMaintenance.Result.Active)
                Console.WriteLine("\t" + m.Name);

            Console.WriteLine("Upcoming maintenance");
            foreach (var m in listMaintenance.Result.Upcoming)
                Console.WriteLine("\t" + m.Name);

            Console.WriteLine("Resolved maintenance");
            foreach (var m in listMaintenance.Result.Resolved)
                Console.WriteLine("\t" + m.Name);
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
                CurrentState = OperationalState.Investigating,
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

            if (damien == null)
            {
                await subscribers.AddAsync("email", "damieng@gmail.com");
                damien = listSubscribersBefore.Result.Email.FirstOrDefault(s => s.Address == "damieng@gmail.com");
            }
            await subscribers.UpdateAsync(damien.Id, damien.Address, null, new[] { 
                new Grain {
                    ComponentId = "5564e39*", // your own ids
                    ContainerId = "5564e30*" 
                },
                new Grain
                {
                    ComponentId = "5564e313*",
                    ContainerId = "54f8967e*"
                }
            });

            var listSubscribersAfter = await subscribers.GetListAsync();

            foreach (var result in listSubscribersAfter.Result.Email)
                Console.WriteLine(result.Address + " joined " + result.JoinDate);
        }
    }
}