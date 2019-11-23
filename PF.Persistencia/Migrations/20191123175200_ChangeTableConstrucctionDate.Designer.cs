﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PF.Persistencia.Context;

namespace PF.Persistencia.Migrations
{
    [DbContext(typeof(FinalProjectContext))]
    [Migration("20191123175200_ChangeTableConstrucctionDate")]
    partial class ChangeTableConstrucctionDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PF.Dominio.Model.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConstructionId");

                    b.Property<double>("Cost");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("PF.Dominio.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FamilyId");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PF.Dominio.Model.Construction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<double>("Cost");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Constructions");
                });

            modelBuilder.Entity("PF.Dominio.Model.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("PF.Dominio.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<double>("Price");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PF.Dominio.Model.ItemActivity", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("ActivityId");

                    b.Property<int>("Id");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("State");

                    b.HasKey("ItemId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("ItemActivity");
                });

            modelBuilder.Entity("PF.Dominio.Model.ItemDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConstructionId");

                    b.Property<int>("ContructionId");

                    b.Property<int>("ItemId");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemDetalle");
                });

            modelBuilder.Entity("PF.Dominio.Model.ItemMaterial", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("MaterialId");

                    b.Property<int>("Id");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("State");

                    b.HasKey("ItemId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("ItemsMaterials");
                });

            modelBuilder.Entity("PF.Dominio.Model.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<double>("Price");

                    b.Property<int>("ProviderId");

                    b.Property<int>("State");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("UnitId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("PF.Dominio.Model.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("PF.Dominio.Model.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<double>("CUIT");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("PF.Dominio.Model.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PF.Dominio.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(10);

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("PF.Dominio.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PF.Dominio.Model.Activity", b =>
                {
                    b.HasOne("PF.Dominio.Model.Construction", "Construction")
                        .WithMany("Activities")
                        .HasForeignKey("ConstructionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PF.Dominio.Model.Category", b =>
                {
                    b.HasOne("PF.Dominio.Model.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PF.Dominio.Model.ItemActivity", b =>
                {
                    b.HasOne("PF.Dominio.Model.Activity", "Activity")
                        .WithMany("Items")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PF.Dominio.Model.Item", "Item")
                        .WithMany("Activities")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PF.Dominio.Model.ItemDetalle", b =>
                {
                    b.HasOne("PF.Dominio.Model.Construction", "Construction")
                        .WithMany("ItemsDetalle")
                        .HasForeignKey("ConstructionId");

                    b.HasOne("PF.Dominio.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PF.Dominio.Model.ItemMaterial", b =>
                {
                    b.HasOne("PF.Dominio.Model.Item", "Item")
                        .WithMany("Materials")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PF.Dominio.Model.Material", "Material")
                        .WithMany("Items")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PF.Dominio.Model.Material", b =>
                {
                    b.HasOne("PF.Dominio.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PF.Dominio.Model.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PF.Dominio.Model.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
