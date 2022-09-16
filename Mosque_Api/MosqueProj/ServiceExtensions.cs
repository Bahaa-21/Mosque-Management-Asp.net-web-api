using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MosqueProj.Data;
using System.Text;

namespace MosqueProj;

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

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error => {
            error.Run(async context => 
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new Error
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error , Please Try agin"
                    }.ToString());
                }
            });
        });
    }
}
