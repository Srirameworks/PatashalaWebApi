using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public class Students:Persons
    {
        [Display(Name = "Date of Enrollment")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOE { get; set; }
        [Required]
        public int Class { get; set; }

    }
}