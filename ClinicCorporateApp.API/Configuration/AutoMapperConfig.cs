using ClinicCorporateApp.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicCorporateApp.API.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile));
        }
    }
}
