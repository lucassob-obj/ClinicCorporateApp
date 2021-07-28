using ClinicCorporateApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClinicCorporateApp.Data.Context
{
    public class ClinicCorporateContext : DbContext
    {
        public ClinicCorporateContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
