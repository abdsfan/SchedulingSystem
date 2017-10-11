using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulingSystem.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public DateTime ShiftDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH}")]
        public DateTime EndTime { get; set; }

        public double TotalCost { get; set; }

        public virtual Cap Cap { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Payment Payment { get; set; }
        public DateTime ScheduledOn { get; set; }

    }
}