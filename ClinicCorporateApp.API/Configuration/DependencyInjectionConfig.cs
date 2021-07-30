using ClinicCorporateApp.Data.Repositories;
using ClinicCorporateApp.Manager.Implementations;
using ClinicCorporateApp.Manager.Interfaces.Managers;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicCorporateApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoManager, MedicoManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
        }
    }
}
