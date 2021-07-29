using System.Threading.Tasks;

namespace ClinicCorporateApp.Manager.Interfaces.Repositories
{
    public interface IEspecialidadeRepository
    {
        Task<bool> ExisteAsync(int id);
    }
}
