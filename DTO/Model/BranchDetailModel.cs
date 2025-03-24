using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class BranchDetailModel
    {
        public string? Type { get; set; }
        public int IntId { get; set; }

        public string? StrBranch { get; set; }
        public bool? IsActive { get; set; }
    }
}
