using SchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulingSystem.ViewModels
{

    public class OutstandingBalanceViewModel
    {
        public List<Schedule> ScheduleDetails { get; set; }
        public double TotalBalance { get; set; }
    }
    //public class OutstandingBalance
    //{ 
    //    [Display(Name = "Shift Date")]
    //    public DateTime ShiftDate { get; set; }


    //    [Display(Name = "Shift Cost")]
    //    public double Cost { get; set; }
    //}
}