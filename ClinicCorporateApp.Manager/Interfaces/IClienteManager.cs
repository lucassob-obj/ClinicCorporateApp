using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(NovoCliente cliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente cliente);
    }
}
