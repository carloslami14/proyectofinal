using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class ItemConstructionConfiguration : IEntityTypeConfiguration<ItemConstruction>
    {
        public void Configure(EntityTypeBuilder<ItemConstruction> builder)
        {
            builder.HasKey(ic => new { ic.ConstructionId, ic.ItemId});

            builder.HasOne(ic => ic.Item)
                .WithMany(i => i.Constructions)
                .HasForeignKey(ic => ic.ItemId);

            builder.HasOne(ic => ic.Construction)
                .WithMany(c => c.Items)
                .HasForeignKey(ic => ic.ConstructionId);
        }
    }
}
