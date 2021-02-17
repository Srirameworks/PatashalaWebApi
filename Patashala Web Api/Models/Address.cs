using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public class Address
    {
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string HouseNo { get; set; }

        [StringLength(50)]
        [Required]
        public string Area { get; set; }
        [Required]
        [StringLength(50)]
        public string Village { get; set; }
        [Required]
        [StringLength(50)]
        public string Mandel { get; set; }
        [Required]
        [StringLength(50)]
        public string District { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(6)]
        public string PIN { get; set; }
        public bool IsContactAddress { get; set; }

    }
}