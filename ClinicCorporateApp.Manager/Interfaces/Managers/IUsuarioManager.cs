using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Manager.Interfaces.Managers
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioView>> GetAsync();
        Task<UsuarioView> GetAsync(string login);
        Task<UsuarioView> InsertAsync(NovoUsuario usuario);
        Task<UsuarioView> UpdateMedicoAsync(Usuario usuario);
        Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);
    }
}
