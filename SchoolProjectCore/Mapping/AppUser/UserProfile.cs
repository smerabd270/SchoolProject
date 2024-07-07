using AutoMapper;
using SchoolProjectCore.Features.AppUser.Command.Model;
using SchoolProjectData.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Mapping.AppUser
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<User, AddUserCommand>()
                .ReverseMap();
        }
    }
}
