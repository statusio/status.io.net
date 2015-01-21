using System;
using System.Linq;

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

            var incidents = await client.Incidents.GetListAsync();
            var firstActiveMessage = incidents.Result.Active.First().Messages.First();
            var incidentMessage = await client.Incidents.GetMessageAsync(firstActiveMessage.Id);

            var components = await client.Components.GetListAsync();

            var subscribers = await client.Subscribers.GetListAsync();
            var damien = subscribers.Result.Email.FirstOrDefault(s => s.Address == "damieng@gmail.com");

            if (damien != null)
            {
                var deleteResult = await client.Subscribers.DeleteAsync(damien.Id);
            }

            var addResult = await client.Subscribers.AddAsync("email", "damieng@gmail.com");

            var response = await client.Subscribers.GetListAsync();

            foreach (var result in response.Result.Email)
            {
                Console.WriteLine(result.Address + " joined " + result.JoinDate);
            }
        }
    }
}