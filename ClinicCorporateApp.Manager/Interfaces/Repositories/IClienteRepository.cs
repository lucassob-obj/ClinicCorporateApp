using ClinicCorporateApp.Core.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClinicCorporateApp.Manager.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}
