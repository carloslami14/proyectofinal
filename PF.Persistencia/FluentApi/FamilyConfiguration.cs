using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).HasMaxLength(100);
        }
    }
}
