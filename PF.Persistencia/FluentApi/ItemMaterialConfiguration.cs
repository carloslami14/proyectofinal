using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class ItemMaterialConfiguration : IEntityTypeConfiguration<ItemMaterial>
    {
        public void Configure(EntityTypeBuilder<ItemMaterial> builder)
        {
            builder.HasKey(im => new {  im.ItemId, im.MaterialId });

            builder.HasOne(im => im.Material)
                .WithMany(m => m.Items)
                .HasForeignKey(im => im.MaterialId);

            builder.HasOne(im => im.Item)
                .WithMany(i => i.Materials)
                .HasForeignKey(im => im.ItemId);
        }
    }
}
