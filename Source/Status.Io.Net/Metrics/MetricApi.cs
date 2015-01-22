// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace StatusIo.Metrics
{
    public class MetricApi
    {
        private readonly StatusIoClient client;

        internal MetricApi(StatusIoClient client)
        {
            this.client = client;
        }

        public Task<Response<bool>> Update(Metric metric)
        {
            var culture = CultureInfo.InvariantCulture;
            metric.StatusPageId = client.GetStatusPageId(metric.StatusPageId);
            return client.PostAsync<Response<bool>>("metric/update", new
            {
                metric_id = metric.MetricId,
                statuspage_id = metric.StatusPageId,

                day_avg = metric.DayAverage.ToString(culture),
                day_start = metric.DayStart.ToUnixTimestamp().ToString(culture),
                day_dates = metric.DayDates.Select(d => d.ToFormatString()).ToArray(),
                day_values = metric.DayValues.Select(d => d.ToString(culture)).ToArray(),

                week_avg = metric.WeekAverage.ToString(culture),
                week_start = metric.WeekStart.ToUnixTimestamp().ToString(culture),
                week_dates = metric.WeekDates.Select(d => d.ToFormatString()).ToArray(),
                week_values = metric.WeekValues.Select(d => d.ToString(culture)).ToArray(),

                month_avg = metric.MonthAverage.ToString(culture),
                month_start = metric.MonthStart.ToUnixTimestamp().ToString(culture),
                month_dates = metric.MonthDates.Select(d => d.ToFormatString()).ToArray(),
                month_values = metric.MonthValues.Select(d => d.ToString(culture)).ToArray()
            });
        }
    }
}