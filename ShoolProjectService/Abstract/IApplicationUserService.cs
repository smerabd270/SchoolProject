﻿using SchoolProjectData.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Abstract
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
