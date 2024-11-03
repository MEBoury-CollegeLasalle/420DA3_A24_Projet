using _420DA3_A24_Projet.Business.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.DataAccess.Contexts
{
    
    internal class WsysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("")
                .UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region USER
            _ = modelBuilder.Entity<User>()
                .ToTable(nameof(this.Users))
                .HasKey(user => user.Id);
            _ = modelBuilder.Entity<User>()
                .HasIndex(user => user.Username)
                .IsUnique(true);
           _ =  modelBuilder.Entity<User>()
                .Property(user => user.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasColumnName("Username")
                .HasColumnOrder(1)
                .HasColumnType($"nvarchar({User.USERNAME_MAX_LENGTH})")
                .HasMaxLength(User.USERNAME_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnOrder(2)
                .HasColumnType($"nvarchar({User.PASSWORD_MAX_LENGTH})")
                .HasMaxLength(User.PASSWORD_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.EmployeeWarehouseId)
                .HasColumnName("EmployeeWarehouseId")
                .HasColumnOrder(3)
                .HasColumnType("int)")
                .IsRequired(false);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnOrder(4)
                .HasColumnType("datetime2)")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(true);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(5)
                .HasColumnType("datetime2)")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.DateDeleted)
                .HasColumnName("DateDeleted")
                .HasColumnOrder(6)
                .HasColumnType("datetime2)")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);
            _ = modelBuilder.Entity<User>()
                .Property(user => user.RowVersion)
                .HasColumnName("RowVersion")
                .HasColumnOrder(7)
                .IsRowVersion();
            _ = modelBuilder.Entity<User>()
                .HasMany(user => user.Roles)
                .WithMany(role => role.Users);
            #endregion
            #region ROLE

            #endregion

            #region PURCHASEORDER

            #endregion
            #region SUPPLIER

            #endregion



        }
    }
}
