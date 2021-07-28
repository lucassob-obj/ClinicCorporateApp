using System.Collections.Generic;

namespace ClinicCorporateApp.Core.Domain
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
