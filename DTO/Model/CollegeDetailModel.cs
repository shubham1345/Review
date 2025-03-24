using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class CollegeDetailModel
    {
        public string Type { get; set; }
        public int IntId { get; set; }

        public string? StrCollegeName { get; set; }

        public string? StrCollegeAddress { get; set; }

        public string? StrAffiliationNumber { get; set; }

        public string? StrContactNo { get; set; }

        public string? StrEmail { get; set; }

        public string? StrPhoneNo { get; set; }

        public bool? IsActive { get; set; }

        public int? IntCreatedBy { get; set; }

        public DateTime? DteCreatedDate { get; set; }

        public int? IntModifiedBy { get; set; }
        public DateTime? DteModifiedDate { get; set; }

    }
}
