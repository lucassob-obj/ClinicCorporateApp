using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Manager.Interfaces.Managers
{
    public interface IClienteManager
    {
        Task<ClienteView> DeleteClienteAsync(int id);
        Task<ClienteView> GetClienteAsync(int id);
        Task<IEnumerable<ClienteView>> GetClientesAsync();
        Task<ClienteView> InsertClienteAsync(NovoCliente cliente);
        Task<ClienteView> UpdateClienteAsync(AlteraCliente cliente);
    }
}
