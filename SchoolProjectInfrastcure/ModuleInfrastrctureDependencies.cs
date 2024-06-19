using Microsoft.Extensions.DependencyInjection;
using SchoolProjectInfrastrcure.Abstract;
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
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
