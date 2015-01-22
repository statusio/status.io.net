// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;
using Newtonsoft.Json;

namespace StatusIo.Metrics
{
    public class Metric
    {
        public string StatusPageId { get; set; }
        public string MetricId { get; set; }

        public decimal DayAverage { get; set; }
        public DateTime DayStart { get; set; }
        public DateTime[] DayDates { get; set; }

        [JsonProperty(PropertyName = "day_values")]
        public decimal[] DayValues { get; set; }

        [JsonProperty(PropertyName = "week_avg")]
        public decimal WeekAverage { get; set; }

        [JsonProperty(PropertyName = "week_start")]
        public DateTime WeekStart { get; set; }

        [JsonProperty(PropertyName = "week_dates")]
        public DateTime[] WeekDates { get; set; }

        [JsonProperty(PropertyName = "week_values")]
        public decimal[] WeekValues { get; set; }

        [JsonProperty(PropertyName = "month_avg")]
        public decimal MonthAverage { get; set; }

        [JsonProperty(PropertyName = "month_start")]
        public DateTime MonthStart { get; set; }

        [JsonProperty(PropertyName = "month_dates")]
        public DateTime[] MonthDates { get; set; }

        [JsonProperty(PropertyName = "month_values")]
        public decimal[] MonthValues { get; set; }
    }
}