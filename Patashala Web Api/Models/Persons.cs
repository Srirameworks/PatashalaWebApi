using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.Models
{
    public enum IdentityType
    {
        Aadhar=1,VoterId,DrivingLicense,PAN
    }
    public abstract class Persons
    {   
        public int Id { get; set; }
  
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }

        [StringLength(30)]
        [Required]
        public string IdentityNumber { get; set; }
     
        [Required]
        public IdentityType IdentityType { get; set; }

        public bool IsSameAddress { get; set; }

        public List<Address> address { get; set; }
    }
}