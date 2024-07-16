using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Helpers;
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

        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
        {
            {
                services.AddIdentity<User, Role>(option =>
                {
                    // Password settings.
                    option.Password.RequireDigit = true;
                    option.Password.RequireLowercase = true;
                    option.Password.RequireNonAlphanumeric = true;
                    option.Password.RequireUppercase = true;
                    option.Password.RequiredLength = 6;
                    option.Password.RequiredUniqueChars = 1;

                    // Lockout settings.
                    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    option.Lockout.MaxFailedAccessAttempts = 5;
                    option.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    option.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    option.User.RequireUniqueEmail = true;
                    option.SignIn.RequireConfirmedEmail = true;

                }).AddEntityFrameworkStores<ApplicationDBContext>();
                //JWT Authentication
                var jwtSettings = new JwtSettings();
                var emailSettings = new EmailSettings();
                configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
                configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

                services.AddSingleton(jwtSettings);
                services.AddSingleton(emailSettings);

                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = jwtSettings.ValidateIssuer,
                       ValidIssuers = new[] { jwtSettings.Issuer },
                       ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                       ValidAudience = jwtSettings.Audience,
                       ValidateAudience = jwtSettings.ValidateAudience,
                       ValidateLifetime = jwtSettings.ValidateLifeTime,
                   };

               });

               
                    return services;
            }
        }
    }
}
