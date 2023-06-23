using ECommerce.Base.Jwt;
using ECommerce.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Service.RestExtension;
using ECommerce.Base.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ECommerce.Service;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public static JwtConfig JwtConfig { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

        services.AddControllers(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddControllersWithViews(options =>
        options.CacheProfiles.Add(ResponseCasheType.Minute45, new CacheProfile
        {
            Duration = 45 * 60,
            NoStore = false,
            Location = ResponseCacheLocation.Any
        }));
        services.AddResponseCompression();
        services.AddMemoryCache();
        services.AddCustomSwaggerExtension();
        services.AddDbContextExtension(Configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddMapperExtension();
        services.AddRepositoryExtension();
        services.AddServiceExtension();
        services.AddJwtExtension();


    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelsExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECom");
            c.DocumentTitle = "ECom";
        });

      

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}