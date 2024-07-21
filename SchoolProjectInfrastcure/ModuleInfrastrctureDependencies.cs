using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.InfrastructureBases;
using SchoolProjectInfrastrcure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure
{
    public static class ModuleInfrastrctureDependencies
    {
        public static IServiceCollection AddInfrastrctureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();



            return services;
        }
    }
}
