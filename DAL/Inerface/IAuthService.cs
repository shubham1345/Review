using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static DTO.Model.UserModel;

namespace DAL.Inerface
{
    public interface IAuthService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
        Task<UserDTO> GetLoginDetail(LoginDto model);
        Task<ResponseModel> InsertUpdateDeleteUserAsync(User param);
        Task<bool> VerifyPasswordHash(string password, string storedHash);
        Task<string> ComputeHash(string password);
    }
}
