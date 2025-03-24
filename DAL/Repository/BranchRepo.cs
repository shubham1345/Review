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
    public class BranchRepo : IBranchService
    {
        private readonly IDapper _dapper;

        public BranchRepo(IDapper idapper)
        {
            _dapper = idapper;
        }

        public async Task<IEnumerable<BranchDetailModel>> GetAllBranchsAsync(int? id = 0)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("IntId", id, DbType.Int32);
                var List = await _dapper.GetAllAsync<BranchDetailModel>(Procedure.GetBranchDetails, dbparams, commandType: CommandType.StoredProcedure);
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> InsertUpdateDeleteBranchsAsync(BranchDetailModel param)
        {
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("IntId", param.IntId, DbType.Int32);
                dbparams.Add("Type", param.Type, DbType.String);
                dbparams.Add("@strBranch", param.StrBranch, DbType.String);
                dbparams.Add("@IsActive", param.IsActive, DbType.Boolean);
                 

                var res = await _dapper.InsertAsync<ResponseModel>(Procedure.InsertUpdateDeleteBranch, dbparams, commandType: CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
