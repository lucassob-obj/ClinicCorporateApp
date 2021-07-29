using ClinicCorporateApp.Data.Context;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Data.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClinicCorporateContext context;
        public EspecialidadeRepository(ClinicCorporateContext context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await context.Especialidades.FindAsync(id) != null;
        }
    }
}
