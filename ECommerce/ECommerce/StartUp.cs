using ECommerce.Base.Jwt;
using ECommerce.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Service.RestExtension;
using ECommerce.Base.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ECommerce.Data.Domain;
using ECommerce.Operation.ProductSrvc;

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


        var dbType = Configuration.GetConnectionString("DbType");
        if (dbType == "SQL")
        {
            var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<EComDbContext>(opts =>
            opts.UseSqlServer(dbConfig));
        }
        else if (dbType == "PostgreSql")
        {
            var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddDbContext<EComDbContext>(opts =>
              opts.UseNpgsql(dbConfig));
        }

       

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
        services.AddScoped<IProductService, ProductService>();
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