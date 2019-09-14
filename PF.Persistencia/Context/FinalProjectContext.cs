using PF.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;




namespace PF.Persistencia.Context
{
    public class FinalProjectContext: DbContext, IFinalProjectContext
    {
        public FinalProjectContext()
        {
        }
        public FinalProjectContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //   .SetBasePath()
            //   .AddJsonFile("appsettings.json")
            //   .Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));

            //if (!optionsBuilder.IsConfigured)
            //{
            //    // MySql
            //    //optionsBuilder.UseMySQL("server=localhost;port=33060;database=FinalProject;Uid=root;Pwd=C@rl0sLam1!;");

            //    // Sql Server
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-6EN2SIQ\\SQLEXPRESS;Database=ProyectoFinal;Trusted_Connection=True;MultipleActiveResultSets=true;");

            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

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

    }
}