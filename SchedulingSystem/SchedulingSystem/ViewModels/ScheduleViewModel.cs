using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingSystem.ViewModels
{
    public class ScheduleViewModel
    {
    }

    public class ShowScheduledShiftsViewModel
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public int ResourceId { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Start { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime End { get; set; }
        [JsonProperty]
        public string Title { get; set; }
    }
}