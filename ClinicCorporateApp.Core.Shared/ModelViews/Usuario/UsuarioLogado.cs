using System.Collections.Generic;

namespace ClinicCorporateApp.Core.Shared.ModelViews.Usuario
{
    public class UsuarioLogado
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public ICollection<FuncaoView> Funcoes { get; set; }
    }
}
