using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public virtual PaymentType PaymentType { get; set; }

    }
}