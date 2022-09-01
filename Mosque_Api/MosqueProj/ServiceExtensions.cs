using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MosqueProj.Data;
using MosqueProj.Entities;
using System;
using System.Text;

namespace MosqueProj
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUsers>(q =>
                { 
                q.User.RequireUniqueEmail = true ;
                q.Password.RequiredUniqueChars = 1 ;
                q.Password.RequireUppercase = false;
                });

            builder = new IdentityBuilder(builder.UserType , typeof(IdentityRole) , services);
            builder.AddEntityFrameworkStores<MosqueDbContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services , IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");

            var key = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                };
            });
        }

    }
}
