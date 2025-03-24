using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class UserModel
    {
        public class User
        {
            public int IntId { get; set; }

            public string? Type { get; set; }
            public string? StrFirstName { get; set; }

            public string? StrMiddleName { get; set; }

            public string? StrLastName { get; set; }

            public string? StrPhoneNo { get; set; }

            public string? StrEmail { get; set; }

            public int? IntGenderId { get; set; }

            public string? StrUserName { get; set; }

            public string? StrPassword { get; set; }

            public string? StrHashpassword { get; set; }
            public string? RefreshToken { get; set; }
            public DateTime RefreshTokenExpiryTime { get; set; }

            public int? IntRoleId { get; set; }

            public bool? IsActive { get; set; }

            public int? IntCreatedBy { get; set; }

            public DateTime? DteCreatedDate { get; set; }

            public int? IntModifiedBy { get; set; }

            public DateTime? DteModifiedDate { get; set; } 
        }

        public class UserDTO
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; } // Store hashed passwords
            public string? RefreshToken { get; set; }
            public DateTime RefreshTokenExpiryTime { get; set; }
            public string Role { get; set; }
            //public List<string> Roles { get; set; } for multiple role to same user
        }

        public class RefreshToken
        {
            public string Token { get; set; }
            public DateTime ExpiryDate { get; set; }
            public int UserId { get; set; }
            public UserDTO User { get; set; }
        }

        public class JwtSettings
        {
            public string Secret { get; set; }
            public TimeSpan AccessTokenExpiration { get; set; }
            public TimeSpan RefreshTokenExpiration { get; set; }
        }
        public class TokenDto
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }
        public class LoginDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        
        public class UserDetailByUserNRefreshToken
        {
            public string? Username { get; set; }
            public string? RefreshToken { get; set; } 
        }

    }
}
