using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.FluentApi
{
    public class ItemItemConfiguration : IEntityTypeConfiguration<ItemItem>
    {
        public void Configure(EntityTypeBuilder<ItemItem> builder)
        {
        //    builder.HasKey(ii => new { ii.FatherItemId, ii.ChilItemId });

        //    builder.HasOne(ii => ii.ChildItem)
        //        .WithMany(ci => ci.Items)
        //        .HasForeignKey(ii => ii.ChilItemId);

        //    builder.HasOne(ii => ii.FatherItem)
        //        .WithMany(fi => fi.Items)
        //        .HasForeignKey(ii => ii.FatherItemId);
        }
    }
}
