using DAL.Inerface;
using DTO.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineExamBoardApi.Models;
using System.Security.Claims;
using System.Text;
using static DTO.Model.UserModel;

namespace OnlineExamBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DbOnlineExamBoardContext _context;
        private readonly IAuthService _authService;
        private readonly JwtSettings _jwtSettings;

        public AuthController(DbOnlineExamBoardContext context, IAuthService authService, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _authService = authService;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authService.GetLoginDetail(loginDto);

            if (user == null || !await _authService.VerifyPasswordHash(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };  // ** for multiple role to same user //.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role.StrRole)));
        
            var accessToken = _authService.GenerateAccessToken(claims);
            var refreshToken = _authService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.Add(_jwtSettings.RefreshTokenExpiration);

            
            User cls = new User();
            cls.Type = "Token";
            cls.IntId = user.Id;
            cls.RefreshToken = user.RefreshToken;
            cls.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            cls.IntModifiedBy = user.Id;
            await _authService.InsertUpdateDeleteUserAsync(cls);
             

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var principal = _authService.GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var username = principal.Identity.Name;

            LoginDto data = new LoginDto();
            data.Username = username;

            var user = await _authService.GetLoginDetail(data);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return Unauthorized();
            }

            var newAccessToken = _authService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _authService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.Add(_jwtSettings.RefreshTokenExpiration);

            User cls = new User();
            cls.Type = "Token";
            cls.IntId = user.Id;
            cls.RefreshToken = user.RefreshToken;
            cls.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            cls.IntModifiedBy = user.Id;
            await _authService.InsertUpdateDeleteUserAsync(cls);

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string username)
        {
            LoginDto data = new LoginDto();
            data.Username = username;
            var user = await _authService.GetLoginDetail(data);

            return Ok(user != null ? (user.Role != null ? user.Role : "") : "");
        }

        //[HttpPost("InsertUpdateDeleteUser")]
        //[Authorize]
        //public async Task<IActionResult> InsertUpdateDeleteUser(User model)
        //{
        //    try
        //    {
        //        model.StrHashpassword = await _authService.ComputeHash(model.StrPassword);
        //        var user = await _authService.InsertUpdateDeleteUserAsync(model);
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(null);
        //    }
        //}

    }

}
