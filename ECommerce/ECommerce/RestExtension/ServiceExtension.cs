using Microsoft.AspNetCore.Authentication;

namespace ECommerce.Service.RestExtension;

public static class ServiceExtension
{
    public static void AddServiceExtension(this IServiceCollection services)
    {
        
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}
