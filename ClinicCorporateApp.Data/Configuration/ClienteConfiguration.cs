﻿using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClinicCorporateApp.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Sexo).HasConversion(p => p.ToString(), p => (Sexo)Enum.Parse(typeof(Sexo), p));
        }
    }
}
