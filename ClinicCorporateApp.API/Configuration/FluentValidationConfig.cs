using ClinicCorporateApp.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace ClinicCorporateApp.API.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddControllers()//.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(x =>
                {
                    x.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    x.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}
