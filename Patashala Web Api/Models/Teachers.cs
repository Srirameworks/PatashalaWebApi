using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public class Teachers:Administrative
    {
        [Required]
        public List<Subject> subject { get; set; }
        [Required]
        public float Salary { get; set; }
    }
}