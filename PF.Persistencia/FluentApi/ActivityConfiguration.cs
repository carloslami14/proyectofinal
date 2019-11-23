using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.HasOne(a => a.Construction)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.ConstructionId);
            builder.HasMany(a => a.Items);
        }
    }
}
