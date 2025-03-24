using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerface
{
    public interface ICommonService
    {
        Task<IEnumerable<GenderModel>> GetAllGenderAsync();
        Task<IEnumerable<MenuModel>> GetAllMenuByRole(int roleId); 
    }
}
