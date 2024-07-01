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
using static SchoolProjectCore.Features.Departments.Queries.Response.GetDepartmentByIdResponse;

namespace SchoolProjectCore.Mapping.Departments
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.GetLocalized()))
                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.InstructortList, opt => opt.MapFrom(src => src.Instructors));
            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StuID));
            CreateMap<Subject, SubjectResponse>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized()))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubjectId));
            CreateMap<Instructor, InstructortResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized()))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId));






        }
    }
}
