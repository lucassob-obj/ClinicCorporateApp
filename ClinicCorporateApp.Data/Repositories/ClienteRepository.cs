using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicCorporateApp.Manager.Interfaces;

namespace ClinicCorporateApp.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClinicCorporateContext context;

        public ClienteRepository(ClinicCorporateContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await context.Clientes
                .Include(p => p.Endereco)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await context.Clientes
                .Include(p => p.Endereco)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        //Insert
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }

        //Update
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await context.Clientes.FindAsync(cliente.Id);
            if (clienteConsultado == null) return clienteConsultado;

            context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            context.Clientes.Update(clienteConsultado);
            await context.SaveChangesAsync();
            return clienteConsultado;
        }

        //Delete
        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsultado = await context.Clientes.FindAsync(id);
            context.Clientes.Remove(clienteConsultado);
            await context.SaveChangesAsync();

        }
    }
}
