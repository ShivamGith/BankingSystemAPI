using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateEMI.Controllers.Models
{
    public class LoanUsers
    {
        public String? Id { get; set; }
        public String? name {get; set;}
        public int age {get; set;}
        public String? email{get; set;}
        public String? pan {get; set;}
        public long aadhar {get; set;}
        public int pincode {get; set;}
        public String? mobile {get; set;}
        public String? address {get; set;}
        public String? father {get; set;}
        public String? mother {get; set;}
        public DateOnly DOB {get; set;}
        public String? Gender {get; set;}
        public String? city {get; set;}
        public String? state {get; set;}
        public String? nationality {get; set;}
    }
}