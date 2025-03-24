using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class StudentDetailModel
    {
        public int IntId { get; set; }

        public string? Type { get; set; }
        public string? StrFirstName { get; set; }

        public string? StrMiddleName { get; set; }

        public string? StrLastName { get; set; }

        public string? StrPhoneNo { get; set; }

        public string? StrEmail { get; set; }

        public int? IntGenderId { get; set; }
        public int? intCollegeId { get; set; }
        public int? intBranchId { get; set; }
        public string? strProfilePhoto { get; set; }
        public string? StrUserName { get; set; }

        public string? StrPassword { get; set; }

        public string? StrHashpassword { get; set; } 

        public bool? IsActive { get; set; }

        public int? IntCreatedBy { get; set; }

        public DateTime? DteCreatedDate { get; set; }

        public int? IntModifiedBy { get; set; }

        public DateTime? DteModifiedDate { get; set; }
    }

}
