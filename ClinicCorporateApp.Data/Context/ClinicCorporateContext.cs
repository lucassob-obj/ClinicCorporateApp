using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ClinicCorporateApp.Data.Context
{
    public class ClinicCorporateContext : DbContext
    {
        public ClinicCorporateContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
