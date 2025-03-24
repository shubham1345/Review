using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerface
{
    public interface ICollegeService
    {
        Task<IEnumerable<CollegeDetailModel>> GetAllCollegesAsync(int? id);
        Task<ResponseModel> InsertUpdateDeleteCollegesAsync(CollegeDetailModel param);

    }
}
