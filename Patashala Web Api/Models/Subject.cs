using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Subject Name")]
        [StringLength(50)]
        public string SubjectName { get; set; }
    }
}