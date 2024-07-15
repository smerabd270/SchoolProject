using SchoolProject.Data.Results;
using SchoolProjectData.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Abstract
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GetJWTToken(User user);
    }
}
