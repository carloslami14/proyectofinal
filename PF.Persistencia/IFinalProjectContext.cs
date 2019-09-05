using Microsoft.EntityFrameworkCore;
using PF.Dominio.Model;

namespace PF.Persistencia
{
    public interface IFinalProjectContext
    {
        DbSet<Activity> Activities { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Construction> Constructions { get; set; }
        DbSet<Family> Families { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Provider> Providers { get; set; }
        DbSet<Rol> Roles { get; set; }
        DbSet<User> Users { get; set; }
    }
}