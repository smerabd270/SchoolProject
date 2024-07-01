using AutoMapper;
using SchoolProjectCore.Features.Departments.Queries.Models;
using SchoolProjectCore.Features.Departments.Queries.Response;
using SchoolProjectCore.Queries.Response;
using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Mapping.Departments
{
    public  class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.GetLocalized()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.DID));



        }
    }
}
