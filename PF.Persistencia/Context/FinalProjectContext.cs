using PF.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using PF.Persistencia.FluentApi;
using System.Linq;

namespace PF.Persistencia.Context
{
    public class FinalProjectContext: DbContext, IFinalProjectContext
    {
        #region Constructor
        public FinalProjectContext()
        {
        }
        public FinalProjectContext(DbContextOptions options)
        : base(options)
        {
        }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Fluent Api
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new ConstructionConfiguration());
            modelBuilder.ApplyConfiguration(new ItemActivityConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemItemConfiguration());
            #endregion
        }
        #endregion

        #region Properties
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Construction> Constructions { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ItemMaterial> ItemsMaterials { get; set; }
        #endregion
    }
}