using DAL.Inerface;
using Dapper;
using DTO.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DTO.Model.UserModel;

namespace DAL.Repository
{
    public class AuthRepo : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDapper _dapper;

        public AuthRepo(IOptions<JwtSettings> jwtSettings, IDapper dapper)
        {
            _jwtSettings = jwtSettings.Value;
            _dapper = dapper;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(_jwtSettings.AccessTokenExpiration),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        public async Task<UserDTO> GetLoginDetail(LoginDto model)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("Username", model.Username, DbType.String);
                 
                var list = await _dapper.GetAsync<UserDTO>(Procedure.GetUserByUserName, dbparams, commandType: CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> InsertUpdateDeleteUserAsync(User param)
        {
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("IntId", param.IntId, DbType.Int32);
                dbparams.Add("Type", param.Type, DbType.String);
                dbparams.Add("strFirstName", param.StrFirstName, DbType.String);
                dbparams.Add("strMiddleName", param.StrMiddleName, DbType.String);
                dbparams.Add("strLastName", param.StrLastName, DbType.String);
                dbparams.Add("strPhoneNo", param.StrPhoneNo, DbType.String);
                dbparams.Add("strEmail", param.StrEmail, DbType.String);
                dbparams.Add("intGenderId", param.IntGenderId, DbType.Int32);
                dbparams.Add("strUserName", param.StrUserName, DbType.String);
                dbparams.Add("strPassword", param.StrPassword, DbType.String);
                dbparams.Add("strHashpassword", param.StrHashpassword, DbType.String);
                dbparams.Add("intRoleId", param.IntRoleId, DbType.Int32);
                dbparams.Add("strRefreshToken", param.RefreshToken, DbType.String);
                dbparams.Add("dteRefreshTokenExpiryTime", param.RefreshTokenExpiryTime, DbType.DateTime);
                dbparams.Add("IsActive", param.IsActive, DbType.Boolean);
                dbparams.Add("intCreatedBy", param.IntCreatedBy, DbType.Int32);
                dbparams.Add("DteCreatedDate", param.DteCreatedDate, DbType.DateTime);
                dbparams.Add("intModifiedBy", param.IntModifiedBy, DbType.Int32);
                dbparams.Add("DteModifiedDate", param.DteModifiedDate, DbType.DateTime);

                var res = await _dapper.InsertAsync<ResponseModel>(Procedure.InsertUpdateDeleteUser, dbparams, commandType: CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false // We don't care about token expiration here
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is JwtSecurityToken jwtSecurityToken &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return principal;
            }

            return null;
        }



        public async Task<bool> VerifyPasswordHash(string password, string storedHash)
        {
            bool isSame = false;
            using var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(password));
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            isSame =  storedHash == computedHash?true:false;
            return isSame;
        }


        public async Task<string> ComputeHash(string password)
        {
            string computedHash = "";
            using var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(password));
            computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computedHash;
        }

    }
}
