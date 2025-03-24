using DAL.Inerface;
using Dapper;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CommonRepo : ICommonService
    {
        private readonly IDapper _dapper;

        public CommonRepo(IDapper idapper)
        {
            _dapper = idapper;
        }

        public async Task<IEnumerable<GenderModel>> GetAllGenderAsync()
        {
            try
            {
                var dbparams = new DynamicParameters(); 
                var List = await _dapper.GetAllAsync<GenderModel>(Procedure.GetAllGender, dbparams, commandType: CommandType.StoredProcedure);
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
   
        
        public async Task<IEnumerable<MenuModel>> GetAllMenuByRole(int roleId)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("@role_id", roleId);
                var List = await _dapper.GetAllAsync<MenuModel>(Procedure.GetAllMenuByRole, dbparams, commandType: CommandType.StoredProcedure);
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
