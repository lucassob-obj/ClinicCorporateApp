using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Data.Context;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicCorporateContext context;

        public UsuarioRepository(ClinicCorporateContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAsync()
        {
            return await context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetAsync(string login)
        {
            return await context.Usuarios.AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Usuario> InsertAsync(Usuario usuario)
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var usuarioConsultado = await context.Usuarios.FindAsync(usuario.Login);
            if (usuarioConsultado == null)
            {
                return null;
            }
            context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await context.SaveChangesAsync();
            return usuarioConsultado;
        }
    }
}
