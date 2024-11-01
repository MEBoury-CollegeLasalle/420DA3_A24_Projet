using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.Business.Domain.Pivots;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.DataAccess.Contexts;
internal class WsysDbContext : DbContext {

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShippingOrder> ShippingOrders { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<ShippingOrderProduct> ShippingOrderProducts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseSqlServer("") // TODO: Add connection string
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);


        // TODO: @TOUTE_EQUIPE Faites la configuration de vos entités et de leur relations ici



    }
}
