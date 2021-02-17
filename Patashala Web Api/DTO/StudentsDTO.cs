using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.DTO
{
    public enum IdentityType
    {
        Aadhar = 1, VoterId, DrivingLicense, PAN
    }
    public class StudentsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string IdentityNumber { get; set; }

        public IdentityType IdentityType { get; set; }
        public DateTime DOE { get; set; }
        public int Class { get; set; }

    }
}