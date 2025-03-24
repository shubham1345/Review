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
    public class CollegeRepo : ICollegeService
    {
        private readonly IDapper _dapper;

        public CollegeRepo(IDapper idapper)
        {
            _dapper = idapper;
        }

        public async Task<IEnumerable<CollegeDetailModel>> GetAllCollegesAsync(int? id = 0)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("IntId", id, DbType.Int32);
                var List = await _dapper.GetAllAsync<CollegeDetailModel>(Procedure.GetCollegeDetails, dbparams, commandType: CommandType.StoredProcedure);
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> InsertUpdateDeleteCollegesAsync(CollegeDetailModel param)
        {
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("IntId", param.IntId, DbType.Int32);
                dbparams.Add("Type", param.Type, DbType.String);
                dbparams.Add("@strCollegeName", param.StrCollegeName, DbType.String);
                dbparams.Add("@strCollegeAddress", param.StrCollegeAddress, DbType.String);
                dbparams.Add("@strAffiliationNumber", param.StrAffiliationNumber, DbType.String);
                dbparams.Add("@strContactNo", param.StrContactNo, DbType.String);
                dbparams.Add("@strEmail", param.StrEmail, DbType.String);
                dbparams.Add("@strPhoneNo", param.StrPhoneNo, DbType.String);
                dbparams.Add("@IsActive", param.IsActive, DbType.Boolean);
                dbparams.Add("@intCreatedBy", param.IntCreatedBy, DbType.Int32);
                dbparams.Add("@DteCreatedDate", param.DteCreatedDate, DbType.DateTime);
                dbparams.Add("@intModifiedBy", param.IntModifiedBy, DbType.Int32);
                dbparams.Add("@DteModifiedDate", param.DteModifiedDate, DbType.DateTime);

                var res = await _dapper.InsertAsync<ResponseModel>(Procedure.InsertUpdateDeleteCollege, dbparams, commandType: CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
