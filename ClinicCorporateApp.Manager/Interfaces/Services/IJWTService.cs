using ClinicCorporateApp.Core.Domain;
using Microsoft.Extensions.Configuration;

namespace ClinicCorporateApp.Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}
