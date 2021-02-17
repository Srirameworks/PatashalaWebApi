using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public class AuthModel
    {
        public AuthModel()
        {
            TokenExpiration = DateTime.Now;
        }
        [Key]
        public int AuthId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string AppToken { get; set; }

        [Required]
        [StringLength(32)]
        public string AppSecret { get; set; }

        [DefaultValue(typeof(DateTime))]
        public DateTime TokenExpiration { get; set; }
    }
}