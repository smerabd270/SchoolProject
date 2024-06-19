using AutoMapper;
using SchoolProjectCore.Features.Students.Command.Models;
using SchoolProjectCore.Queries.Response;
using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Mapping.Students
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentListResponse>()
                .ForMember(dest=>dest.DepartmentName,opt=>opt.MapFrom(dest=>dest.Departments.DName));
            CreateMap<Student, GetStudentSingleResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(dest => dest.Departments.DName));
            CreateMap<Student, AddStudentCommand>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(dest => dest.DID))
            .ReverseMap();  


        }
    }
}
