using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulingSystem.Models
{
    public class Cap
    {    
        public int Id { get; set; }
        public int CapNumber { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}