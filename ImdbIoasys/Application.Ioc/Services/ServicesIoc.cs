using Application.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Ioc.Services
{
    public static class ServicesIoc
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
