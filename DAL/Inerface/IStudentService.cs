using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDetailModel>> GetAllStudentsAsync(int? id);
        Task<ResponseModel> InsertUpdateDeleteStudentAsync(StudentDetailModel param);
    }
}
