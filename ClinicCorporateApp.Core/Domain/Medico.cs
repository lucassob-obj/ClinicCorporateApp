using System.Collections.Generic;

namespace ClinicCorporateApp.Core.Domain
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }
    }
}
