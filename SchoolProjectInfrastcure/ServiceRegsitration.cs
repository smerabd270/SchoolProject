using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProjectData.Entities.Identity;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
using SchoolProjectInfrastrcure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure
{
    public static class ServiceRegsitration
    {
        //public static IServiceCollection AddServiceRegsitration(this IServiceCollection services)
        //{
        //    services.AddIdentity<User, IdentityRole>(option =>
        //    {
        //        // Password settings.
        //        option.Password.RequireDigit = true;
        //        option.Password.RequireLowercase = true;
        //        option.Password.RequireNonAlphanumeric = true;
        //        option.Password.RequireUppercase = true;
        //        option.Password.RequiredLength = 6;
        //        option.Password.RequiredUniqueChars = 1;

        //        // Lockout settings.
        //        option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //        option.Lockout.MaxFailedAccessAttempts = 5;
        //        option.Lockout.AllowedForNewUsers = true;

        //        // User settings.
        //        option.User.AllowedUserNameCharacters =
        //        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        //        option.User.RequireUniqueEmail = true;
        //        option.SignIn.RequireConfirmedEmail = true;
        //    }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        //    return services;
        //}
    }
}
