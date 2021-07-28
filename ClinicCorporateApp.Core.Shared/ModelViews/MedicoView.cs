using System.Collections.Generic;

namespace ClinicCorporateApp.Core.Shared.ModelViews
{
    public class MedicoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }

        public ICollection<EspecialidadeView> Especialidades { get; set; }
    }
}
