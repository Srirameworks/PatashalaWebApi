using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public enum AdministrativeRoll
    {
        Teacher = 1, Staff, Attender,Admin
    }
    public abstract class Administrative:Persons
    {
        [Display(Name = "Date of Join")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOJ { get; set; }
        [Required]
        public AdministrativeRoll AdministrativeRoll { get; set; }
    }
}