﻿using ClinicCorporateApp.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicCorporateApp.Data.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(p => new { p.ClienteId, p.Numero });
        }
    }
}
