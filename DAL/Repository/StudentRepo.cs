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
    public class StudentRepo : IStudentService
    {
        private readonly IDapper _dapper;

        public StudentRepo(IDapper idapper)
        {
            _dapper = idapper;
        }


        public async Task<IEnumerable<StudentDetailModel>> GetAllStudentsAsync(int? id = 0)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("IntId", id, DbType.Int32);
                var List = await _dapper.GetAllAsync<StudentDetailModel>(Procedure.GetStudentDetails, dbparams, commandType: CommandType.StoredProcedure);
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<ResponseModel> InsertUpdateDeleteStudentAsync(StudentDetailModel param)
        {
            if (param.StrPassword != null)
            {
                using var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(param.StrPassword));
                param.StrHashpassword = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(param.StrPassword)));
            }
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("IntId", param.IntId, DbType.Int32);
                dbparams.Add("Type", param.Type, DbType.String);
                dbparams.Add("StrFirstName", param.StrFirstName, DbType.String);
                dbparams.Add("StrMiddleName", param.StrMiddleName, DbType.String);
                dbparams.Add("StrLastName", param.StrLastName, DbType.String);
                dbparams.Add("StrPhoneNo", param.StrPhoneNo, DbType.String);
                dbparams.Add("StrEmail", param.StrEmail, DbType.String);
                dbparams.Add("IntGenderId", param.IntGenderId, DbType.Int32);
                dbparams.Add("intCollegeId", param.intCollegeId, DbType.Int32);
                dbparams.Add("intBranchId", param.intBranchId, DbType.Int32);
                dbparams.Add("strProfilePhoto", param.strProfilePhoto, DbType.String);
                dbparams.Add("StrUserName", param.StrUserName, DbType.String);
                dbparams.Add("StrPassword", param.StrPassword, DbType.String);
                dbparams.Add("StrHashpassword", param.StrHashpassword, DbType.String);
                dbparams.Add("IsActive", param.IsActive, DbType.Boolean);
                dbparams.Add("IntCreatedBy", param.IntCreatedBy, DbType.Int32);
                dbparams.Add("DteCreatedDate", param.DteCreatedDate, DbType.DateTime);
                dbparams.Add("IntModifiedBy", param.IntModifiedBy, DbType.Int32);
                dbparams.Add("DteModifiedDate", param.DteModifiedDate, DbType.DateTime);


                var res = await _dapper.InsertAsync<ResponseModel>(Procedure.InsertUpdateDeleteStudent, dbparams, commandType: CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}
