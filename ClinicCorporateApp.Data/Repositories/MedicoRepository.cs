using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Data.Context;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Data.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicCorporateContext context;

        public MedicoRepository(ClinicCorporateContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await context.Medicos
              .Include(p => p.Especialidades)
              .AsNoTracking().ToListAsync();
        }

        public async Task<Medico> GetMedicoAsync(int id)
        {
            return await context.Medicos
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertMedicoEspecialidade(medico);
            await context.Medicos.AddAsync(medico);
            await context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertMedicoEspecialidade(Medico medico)
        {
            var especialidadesConsultadas = new List<Especialidade>();

            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context.Especialidades.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(especialidadeConsultada);
            }

            medico.Especialidades = especialidadesConsultadas;
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoConsultado = await context.Medicos
                                        .Include(p => p.Especialidades)
                                        .SingleOrDefaultAsync(p => p.Id == medico.Id);
            if (medicoConsultado == null)
            {
                return null;
            }
            await UpdateMedicoEspecialidade(medico, medicoConsultado);
            context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            await context.SaveChangesAsync();
            return medicoConsultado;
        }

        private async Task UpdateMedicoEspecialidade(Medico medicoConsultado, Medico medico)
        {
            var arrayDeEspecialidades = medico.Especialidades.Select(s => s.Id).ToArray();
            List<Especialidade> especialidades = await context.Especialidades.Where(w => arrayDeEspecialidades.Contains(w.Id)).ToListAsync();
            medicoConsultado.Especialidades = especialidades;
        }

        public async Task DeleteMedicoAsync(int id)
        {
            var medicoConsultado = await context.Medicos.FindAsync(id);
            context.Medicos.Remove(medicoConsultado);
            await context.SaveChangesAsync();
        }
    }
}
