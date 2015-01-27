// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using StatusIo.Incidents;

namespace StatusIo.Maintenance
{
    public class MaintenanceApi
    {
        private readonly StatusIoClient client;

        internal MaintenanceApi(StatusIoClient client)
        {
            this.client = client;
        }

        public Task<Response<MaintenanceList>> GetList(string statusPageId = null)
        {
            return client.GetAsync<Response<MaintenanceList>>(
                "maintenance/list/" + client.GetStatusPageId(statusPageId));
        }

        public Task<Response<MaintenanceMessage>> GetMessage(string messageId, string statusPageId = null)
        {
            return client.GetAsync<Response<MaintenanceMessage>>(
                "maintenance/message/" + client.CleanAndValidateId(messageId)
                + "/" + client.GetStatusPageId(statusPageId));
        }

        public Task<Response<string>> Schedule(MaintenanceSchedule schedule)
        {
            return client.PostAsync<Response<string>>("maintenance/schedule", new
            {
                statuspage_id = client.GetStatusPageId(schedule.StatusPageId),
                components = schedule.ComponentIds.Select(client.CleanAndValidateId),
                containers = schedule.ContainerIds.Select(client.CleanAndValidateId),
                all_infrastructure_affected = schedule.AllInfrastructureAffected ? "1" : "0",
                maintenance_name = schedule.Name,
                maintenance_details = schedule.Details,
                date_planned_start = schedule.PlannedStart.ToString("dd-MM-yyyy"),
                time_planned_start = schedule.PlannedStart.ToString("HH:mm"),
                date_planned_end = schedule.PlannedEnd.ToString("dd-MM-yyyy"),
                time_planned_end = schedule.PlannedEnd.ToString("HH:mm"),
                maintenance_notify_now = schedule.NotifyNow ? "1" : "0",
                maintenance_notify_24_hr = schedule.Notify24h ? "1" : "0",
                maintenance_notify_1_hr = schedule.Notify1h ? "1" : "0"
            });
        }

        public Task<Response<bool>> Start(Maintenance maintenance)
        {
            return client.PostAsync<Response<bool>>("maintenance/start", CreateMaintenanceBody(maintenance));
        }

        public Task<Response<bool>> Update(Maintenance maintenance)
        {
            return client.PostAsync<Response<bool>>("maintenance/update", CreateMaintenanceBody(maintenance));
        }

        public Task<Response<bool>> Finish(Maintenance maintenance)
        {
            return client.PostAsync<Response<bool>>("maintenance/update", CreateMaintenanceBody(maintenance));
        }

        public Task<Response<string>> Delete(string maintenanceId, string statusPageId = null)
        {
            return client.PostAsync<Response<string>>("maintenance/delete", new
            {
                statuspage_id = client.GetStatusPageId(statusPageId),
                maintenance_id = client.CleanAndValidateId(maintenanceId)
            });
        }

        private object CreateMaintenanceBody(Maintenance schedule)
        {
            return new
            {
                statuspage_id = client.GetStatusPageId(schedule.StatusPageId),
                maintenance_details = schedule.Details,
                notify_email = schedule.NotifyEmail ? "1" : "0",
                notify_sms = schedule.NotifySms ? "1" : "0",
                notify_webhook = schedule.NotifyWebhook ? "1" : "0",
                social = schedule.NotifySocial ? "1" : "0",
                irc = schedule.NotifyIrc ? "1" : "0",
                hipchat = schedule.NotifyHipchat ? "1" : "0",
                slack = schedule.NotifySlack ? "1" : "0",
            };
        }
    }
}