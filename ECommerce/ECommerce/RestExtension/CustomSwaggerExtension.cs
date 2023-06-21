using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace ECommerce.Service.RestExtension;

public static class CustomSwaggerExtension
{
    public static void AddCustomSwaggerExtension(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecom Api Management", Version = "v1.0" });


            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Ecom Management for Ecom Company",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {securityScheme, new string[] { }}
        });
        });
    }
}
