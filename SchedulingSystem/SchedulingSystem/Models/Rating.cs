using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingSystem.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public DateTime DateRated { get; set; }

        public int Score { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Cap Cap { get; set; }

    }
}