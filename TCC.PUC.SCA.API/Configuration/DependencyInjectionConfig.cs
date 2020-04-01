using Microsoft.Extensions.DependencyInjection;
using TCC.PUC.SCA.Business.Intefaces;
using TCC.PUC.SCA.Business.Notificacoes;

namespace TCC.PUC.SCA.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notifier>();

            return services;
        }
    }
}
