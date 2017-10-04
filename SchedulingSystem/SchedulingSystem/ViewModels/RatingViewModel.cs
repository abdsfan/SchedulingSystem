using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulingSystem.ViewModels
{
    public class DataForRatingViewModel
    {

        [Required]
        [Display(Name = "Date of incident")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfDay { get; set; }

        [Required]
        //[StringLength(2, ErrorMessage = "Enter only the hour")]
        [DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\-mm}")]
        [Display(Name = "Hour of day in military time")]
        public DateTime TimeOfDay { get; set; }

        [Required]
        [Display(Name = "Cap Number")]
        [RegularExpression(@"^[0-9]{3}", ErrorMessage = "Invalid Cap Number")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public int CapNumber { get; set; }
    }

    public class ScoringDriver
    {
        public string UserId { get; set; }

        public int CapId { get; set; }

        [Required]
        [Display(Name = "Driver Score")]
        [RegularExpression(@"^[0-9]{1,2}", ErrorMessage = "Invalid rating")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public int DriverScore { get; set; }
    }
}