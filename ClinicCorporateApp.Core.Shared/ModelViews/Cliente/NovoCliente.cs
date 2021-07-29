using ClinicCorporateApp.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;

namespace ClinicCorporateApp.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo cliente.
    /// </summary>
    public class NovoCliente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoView Sexo { get; set; }
        public ICollection<NovoTelefone> Telefones { get; set; }
        public string Documento { get; set; }

        public NovoEndereco Endereco { get; set; }
    }
}
