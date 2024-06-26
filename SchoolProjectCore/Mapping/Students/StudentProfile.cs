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
                .ForMember(dest=>dest.DepartmentName,opt=>opt.MapFrom(dest=>dest.Department.GetLocalized()));
            CreateMap<Student, GetStudentSingleResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(dest => dest.Department.GetLocalized()));
            CreateMap<Student, AddStudentCommand>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(dest => dest.DID))
            .ReverseMap();
            CreateMap<Student, UpdateStudentCommand>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(dest => dest.DID))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.StuID))

            .ReverseMap();


        }
    }
}
