using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class ConstructionConfiguration : IEntityTypeConfiguration<Construction>
    {
        public void Configure(EntityTypeBuilder<Construction> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.HasMany(c => c.Activities);
            builder.Property(c => c.Address).HasMaxLength(100);
        }
    }
}
