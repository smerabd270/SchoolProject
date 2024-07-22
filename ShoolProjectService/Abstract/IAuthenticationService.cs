using SchoolProject.Data.Results;
using SchoolProjectData.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Abstract
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GetJWTToken(User user);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
    }
}
