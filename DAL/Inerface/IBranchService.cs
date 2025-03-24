using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerface
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchDetailModel>> GetAllBranchsAsync(int? id);
        Task<ResponseModel> InsertUpdateDeleteBranchsAsync(BranchDetailModel param);
    }
}
