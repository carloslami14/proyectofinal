using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class ItemActivityConfiguration : IEntityTypeConfiguration<ItemActivity>
    {
        public void Configure(EntityTypeBuilder<ItemActivity> builder)
        {
            builder.HasKey(ia => new { ia.ItemId, ia.ActivityId });

            builder.HasOne(ia => ia.Item)
                .WithMany(i => i.Activities)
                .HasForeignKey(ia => ia.ItemId);

            builder.HasOne(ia => ia.Activity)
                .WithMany(a => a.Items)
                .HasForeignKey(ia => ia.ActivityId);
        }
    }
}
