using _420DA3_A24_Projet.Business.Domain;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.DataAccess.Contexts {

    internal class WsysDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ShippingOrder> ShippingOrders { get; set; }

        public DbSet<Adresse>Adresses { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            _ = optionsBuilder
                // TODO: éventuellement remplacer par un string construit sur les configurations de l'application (fichier App.config).
                .UseSqlServer("Server=.\\SQL2022DEV;Database=420DA3_A24_PROJET;Integrated Security=true;TrustServerCertificate=true;")
                .UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);


            #region USER

            _ = modelBuilder.Entity<User>()
                .ToTable(nameof(this.Users))
                .HasKey(user => user.Id);

            _ = modelBuilder.Entity<User>()
                .HasIndex(user => user.Username)
                .IsUnique(true);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.Id)
                .HasColumnName(nameof(User.Id))
                .HasColumnOrder(0)
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasColumnName(nameof(User.Username))
                .HasColumnOrder(1)
                .HasColumnType($"nvarchar({User.USERNAME_MAX_LENGTH})")
                .HasMaxLength(User.USERNAME_MAX_LENGTH)
                .IsRequired(true);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.PasswordHash)
                .HasColumnName(nameof(User.PasswordHash))
                .HasColumnOrder(2)
                .HasColumnType($"nvarchar({User.PASSWORDHASH_MAX_LENGTH})")
                .HasMaxLength(User.PASSWORDHASH_MAX_LENGTH)
                .IsRequired(true);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.EmployeeWarehouseId)
                .HasColumnName(nameof(User.EmployeeWarehouseId))
                .HasColumnOrder(3)
                .HasColumnType("int")
                .IsRequired(false);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.DateCreated)
                .HasColumnName(nameof(User.DateCreated))
                .HasColumnOrder(4)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.DateModified)
                .HasColumnName(nameof(User.DateModified))
                .HasColumnOrder(5)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .IsRequired(false);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.DateDeleted)
                .HasColumnName(nameof(User.DateDeleted))
                .HasColumnOrder(6)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .IsRequired(false);

            _ = modelBuilder.Entity<User>()
                .Property(user => user.RowVersion)
                .HasColumnName(nameof(User.RowVersion))
                .HasColumnOrder(7)
                .IsRowVersion();


            _ = modelBuilder.Entity<User>()
                .HasOne(user => user.EmployeeWarehouse)
                .WithMany(warehouse => warehouse.WarehouseEmployees)
                .HasForeignKey(user => user.EmployeeWarehouseId)
                .HasPrincipalKey(warehouse => warehouse.Id)
                .OnDelete(DeleteBehavior.SetNull);

            _ = modelBuilder.Entity<User>()
                .HasMany(user => user.CreatedShippingOrders)
                .WithOne(order => order.CreatorEmployee)
                .HasForeignKey(order => order.CreatorEmployeeId)
                .HasPrincipalKey(user => user.Id)
                .IsRequired(true);

            _ = modelBuilder.Entity<User>()
                .HasMany(user => user.FulfilledShippingOrders)
                .WithOne(order => order.FulfillerEmployee)
                .HasForeignKey(order => order.FulfillerEmployeeId)
                .HasPrincipalKey(user => user.Id)
                .IsRequired(false);

            #endregion

            #region ROLE

            _ = modelBuilder.Entity<Role>()
                .ToTable(nameof(this.Roles))
                .HasKey(role => role.Id);

            _ = modelBuilder.Entity<Role>()
                .HasIndex(role => role.Name)
                .IsUnique(true);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.Id)
                .HasColumnName(nameof(Role.Id))
                .HasColumnOrder(0)
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.Name)
                .HasColumnName(nameof(Role.Name))
                .HasColumnOrder(1)
                .HasColumnType($"nvarchar({Role.NAME_MAX_LENGTH})")
                .HasMaxLength(Role.NAME_MAX_LENGTH)
                .IsRequired(true);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.Description)
                .HasColumnName(nameof(Role.Description))
                .HasColumnOrder(2)
                .HasColumnType($"nvarchar({Role.DESCRIPTION_MAX_LENGTH})")
                .HasMaxLength(Role.DESCRIPTION_MAX_LENGTH)
                .IsRequired(true);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.DateCreated)
                .HasColumnName(nameof(Role.DateCreated))
                .HasColumnOrder(3)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.DateModified)
                .HasColumnName(nameof(Role.DateModified))
                .HasColumnOrder(4)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .IsRequired(false);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.DateDeleted)
                .HasColumnName(nameof(Role.DateDeleted))
                .HasColumnOrder(5)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .IsRequired(false);

            _ = modelBuilder.Entity<Role>()
                .Property(role => role.RowVersion)
                .HasColumnName(nameof(Role.RowVersion))
                .HasColumnOrder(6)
                .IsRowVersion();


            #endregion

            #region PURCHASEORDER

            _ = modelBuilder.Entity<PurchaseOrder>()
                .ToTable(nameof(this.PurchaseOrders))
                .HasKey(purchaseOrder => purchaseOrder.Id);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.Status)
                .HasColumnName("Status")
                .HasColumnOrder(1)
                .HasColumnType("nvarchar")
                .IsRequired(true);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.ProductId)
                .HasColumnName("ProductId")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .IsRequired(true);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.WarehouseId)
                .HasColumnName("WarehouseId")
                .HasColumnOrder(3)
                .HasColumnType("int")
                .IsRequired(true);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.Quantity)
                .HasColumnName("Quantity")
                .HasColumnOrder(4)
                .HasColumnType("int")
                .IsRequired(true);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.CompletionDate)
                .HasColumnName("CompletionDate")
                .HasColumnOrder(5)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnOrder(6)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(true);
            _ = modelBuilder.Entity<PurchaseOrder>()
                .Property(purchaseOrder => purchaseOrder.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(7)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);


            #endregion

            #region SUPPLIER
            _ = modelBuilder.Entity<Supplier>()
                .ToTable(nameof(this.Suppliers))
                .HasKey(supplier => supplier.Id);
            _ = modelBuilder.Entity<Supplier>()
                .HasIndex(supplier => supplier.SupplierName)
                .IsUnique(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.SupplierName)
                .HasColumnName("SupplierName")
                .HasColumnOrder(1)
                .HasColumnType($"nvarchar({Supplier.SUPPLIER_NAME_MAX_LENGTH})")
                .HasMaxLength(Supplier.SUPPLIER_NAME_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.ContactLastName)
                .HasColumnName("ContactLastName")
                .HasColumnOrder(2)
                .HasColumnType($"nvarchar({Supplier.CONTACT_LAST_NAME_MAX_LENGTH})")
                .HasMaxLength(Supplier.CONTACT_LAST_NAME_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.ContactFirstName)
                .HasColumnName("ContactFirstName")
                .HasColumnOrder(3)
                .HasColumnType($"nvarchar({Supplier.CONTACT_FIRST_NAME_MAX_LENGTH})")
                .HasMaxLength(Supplier.CONTACT_FIRST_NAME_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.ContactEmail)
                .HasColumnName("ContactEmail")
                .HasColumnOrder(4)
                .HasColumnType($"nvarchar({Supplier.CONTACT_EMAIL_MAX_LENGTH})")
                .HasMaxLength(Supplier.CONTACT_EMAIL_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.ContactTelephone)
                .HasColumnName("ContactTelephone")
                .HasColumnOrder(4)
                .HasColumnType($"nvarchar({Supplier.CONTACT_TELEPHONE_MAX_LENGTH})")
                .HasMaxLength(Supplier.CONTACT_TELEPHONE_MAX_LENGTH)
                .IsRequired(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnOrder(4)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(true);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(5)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);
            _ = modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.DateDeleted)
                .HasColumnName("DateDeleted")
                .HasColumnOrder(6)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);

            #endregion

            #region Adresse
            //configuration minimaliste de l'entite Adresse
            _ = modelBuilder.Entity<Adresse>()
                .ToTable("Adresse")
                .HasKey(adresse => adresse.Id);


            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasColumnOrder(0)
                .UseIdentityColumn(1, 1);



            _ = modelBuilder.Entity<Adresse>()
                 .Property(adresse => adresse.AdressTypes)
                 .HasColumnName("AdressTypes")
                 .HasColumnOrder(1)
                 .IsRequired(true);


            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.Adress)
                .HasColumnName("Adress")
                .HasColumnType($"nvarchar({Adresse.AdresseMaxLength})")
                .HasMaxLength(Adresse.AdresseMaxLength)
                .HasColumnOrder(2)
                .IsRequired(true);


            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.CivicNumber)
                .HasColumnName("CivicNumber")
                .HasColumnType($"int({Adresse.CivicNumberMaxLength})")
                .HasMaxLength(Adresse.CivicNumberMaxLength)
                .HasColumnOrder(3)
                .IsRequired(true);

            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.Street)
                .HasColumnName("Street")
                .HasColumnType($"nvarchar({Adresse.StreeMaxLength})")
                .HasMaxLength(Adresse.StreeMaxLength)
                .HasColumnOrder(4)
                .IsRequired(true);

            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.City)
                .HasColumnName("City")
                .HasColumnType($"nvarchar({Adresse.CityMaxLength})")
                .HasMaxLength(Adresse.CityMaxLength)
                .HasColumnOrder(5)
                .IsRequired(true);



            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.State)
                .HasColumnName("State")
                .HasColumnType($"nvarchar({Adresse.StateMaxLength})")
                .HasMaxLength(Adresse.StateMaxLength)
                .HasColumnOrder(6)
                .IsRequired(true);


            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.Country)
                .HasColumnName("Country")
                .HasColumnType($"nvarchar({Adresse.ContryMaxLength})")
                .HasMaxLength(Adresse.ContryMaxLength)
                .HasColumnOrder(7)
                .IsRequired(true);


            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType($"nvarchar({Adresse.PostalCodeMaxLength})")
                .HasColumnOrder(8)
                .IsRequired(true);


            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnOrder(9)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(true);

            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.DateDelete)
                .HasColumnName("DateDeleted")
                .HasColumnOrder(10)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);

            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(11)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);

            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.OwnerWarehouse)
                .HasColumnName("OwnerWarehouse")
                .HasColumnOrder(12)
                .HasColumnType("Warehouse")
                .IsRequired(false);

            _ = modelBuilder.Entity<Adresse>()
                .Property(adresse => adresse.OwnerShipOrder)
                .HasColumnName("OwnerShipOrder")
                .HasColumnType("ShippingOrder")
                .HasColumnOrder(13)
                .IsRequired();


            _ = modelBuilder.Entity<Adresse>()
               .Property(adresse => adresse.RowVersion)
               .HasColumnName("RowVersion")
               .HasColumnOrder(7)
               .IsRowVersion();

            #endregion

            #region Shipment

            //configurationminimaliste de l'entites Shipment
            _ = modelBuilder.Entity<Shipment>()
                .ToTable("Shipment")
                .HasKey(shipment => shipment.Id);

            //configuration d'un index a contrainte unique pour shipment (TrackinNumber)
            _ = modelBuilder.Entity<Shipment>()
                .HasIndex(shipment => shipment.TrackingNumber)
                .IsUnique(true);

            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasColumnOrder(0)
                .UseIdentityColumn(1, 1);

            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.Status)
                .HasColumnName("Satus")
                .HasColumnOrder(1)
                .IsRequired(true);


            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.ShippingService)
                .HasColumnName("ShippingService")
                .HasColumnType("ShippingProvidersEnum")
                .HasColumnOrder(2)
                .IsRequired(true);

            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.ShippingOrderld)
                .HasColumnName("ShippingOrderld")
                .HasColumnType("int")
                .HasColumnOrder(3)
                .IsRequired(true);

            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.TrackingNumber)
                .HasColumnName("TrackingNumber")
                .HasColumnType("int")
                .HasMaxLength(Shipment.TrackingNumberMaxLength)
                .HasColumnOrder(4);

            _ = modelBuilder.Entity<Shipment>()
              .Property(shipment => shipment.DateCreated)
              .HasColumnName("DateCreated")
              .HasColumnOrder(5)
              .HasColumnType("datetime2")
              .HasPrecision(7)
              .HasDefaultValue("GETDATE()")
              .IsRequired(true);


            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(6)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);


            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.DateDelete)
                .HasColumnName("DateDeleted")
                .HasColumnOrder(7)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValue("GETDATE()")
                .IsRequired(false);


            _ = modelBuilder.Entity<Shipment>()
                .Property(shipment => shipment.ShippingOrder)
                .HasColumnOrder(8)
                .HasColumnType("ShippingOrder")
                .HasPrecision(7)
                .IsRequired(true);


            _ = modelBuilder.Entity<User>()
                .Property(shipment => shipment.RowVersion)
                .HasColumnName("RowVersion")
                .HasColumnOrder(9)
                .IsRowVersion();
            #endregion

            #region Warehouse
            _ = modelBuilder.Entity<Warehouse>()
                .ToTable(nameof(this.Warehouses)).
                HasKey(warehouse => warehouse.Id);

            _ = modelBuilder.Entity<Warehouse>()
                .HasIndex(warehouse => warehouse.Name)
                .IsUnique(true);

            _ = modelBuilder.Entity<Warehouse>()
                .Property(warehouse => warehouse.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int").
                UseIdentityColumn(1, 1);

            _ = modelBuilder.Entity<Warehouse>()
                .Property(warehouse => warehouse.Name)
                .HasColumnName("Name")
                .HasColumnOrder(1)
                .HasColumnType($"nvarchar{Warehouse.WAREHOUSE_NAME_MAX_LENGTH}")
                .HasMaxLength(Warehouse.WAREHOUSE_NAME_MAX_LENGTH)
                .IsRequired(true);

            _ = modelBuilder.Entity<Warehouse>()
                .Property(warehouse => warehouse.AddressId)
                .HasColumnName("AdresseId").
                HasColumnOrder(2)
                .HasColumnType("nvarchar")
                .IsRequired(true);

            _ = modelBuilder.Entity<Warehouse>()
                .Property(warehouse => warehouse.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnOrder(3)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            _ = modelBuilder.Entity<Warehouse>()
                .Property(warehouse => warehouse.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(4)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .IsRequired(false);

            _ = modelBuilder.Entity<Warehouse>()
                 .Property(warehouse => warehouse.DateDeleted)
                 .HasColumnName("DateDeleted")
                 .HasColumnOrder(5)
                 .HasColumnType("datetime2")
                 .HasPrecision(7)
                 .IsRequired(false);

            _ = modelBuilder.Entity<Warehouse>()
                .Property(warehouse => warehouse.RowVersion)
                .HasColumnName("RowVersion")
                .HasColumnOrder(6)
                .IsRowVersion();


            #endregion
            #region ShippingOrderProduct
            _ = modelBuilder.Entity<ShippingOrder>()
                .ToTable(nameof(this.ShippingOrders))
                .HasKey(shippingOrder => shippingOrder.Id);

            _ = modelBuilder.Entity<ShippingOrder>()
                .Property(shippingOrder => shippingOrder.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .HasColumnType("int").
                UseIdentityColumn(1, 1);

            _ = modelBuilder.Entity<ShippingOrder>()
                .Property(shippingOrder => shippingOrder.Status)
                .HasColumnName("Status")
                .HasColumnOrder(1)
                .HasColumnType("ShippingOrderStatusEnum")
                .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
                .Property(shippingOrder => shippingOrder.SourceClientId)
                .HasColumnName("SourceClientId")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
                 .Property(shippingOrder => shippingOrder.CreatorEmployeeId)
                 .HasColumnName("CreatorEmployeeId")
                                .HasColumnOrder(3)
                                .HasColumnType("int")
                                .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
                                       .Property(shippingOrder => shippingOrder.DestinationAddressId)
                                       .HasColumnName("DestinationAddressId")
                                       .HasColumnOrder(4)
                                       .HasColumnType("int")
                                       .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
               .Property(shippingOrder => shippingOrder.FulfillerEmployeeId)
               .HasColumnName("FulfillerEmployeeId")
               .HasColumnOrder(5)
               .HasColumnType("int")
               .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
                           .Property(shippingOrder => shippingOrder.FulfillerEmployeeId)
                           .HasColumnName("FulfillerEmployeeId")
                           .HasColumnOrder(6)
                           .HasColumnType("int")
                           .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
               .Property(shippingOrder => shippingOrder.DateCreated)
               .HasColumnName("DateCreated")
               .HasColumnOrder(7)
               .HasColumnType("datetime2")
               .HasPrecision(7)
               .HasDefaultValueSql("GETDATE()")
               .IsRequired(true);

            _ = modelBuilder.Entity<ShippingOrder>()
                .Property(shippingOrder => shippingOrder.DateModified)
                .HasColumnName("DateModified")
                .HasColumnOrder(8)
                .HasColumnType("datetime2")
                .HasPrecision(7)
                .IsRequired(false);

            _ = modelBuilder.Entity<ShippingOrder>()
                 .Property(shippingOrder => shippingOrder.DateDeleted)
                 .HasColumnName("DateDeleted")
                 .HasColumnOrder(9)
                 .HasColumnType("datetime2")
                 .HasPrecision(7)
                 .IsRequired(false);

            _ = modelBuilder.Entity<ShippingOrder>()
                .Property(shippingOrder => shippingOrder.RowVersion)
                .HasColumnName("RowVersion")
                .HasColumnOrder(9)
                .IsRowVersion();

            #endregion


            #region RELATIONS RE DONNÉES DE TEST

            // Warehouse ici


            // NOTE: le mot de passe des user est "testpasswd".
            User user1 = new User("UserAdmin", "43C39F5E14573CCB5E176B9C701673C3F7031F85C711E9A1B00AB6E4802A7310:F4C024A35DB3B92F9D1AFD928E9D6D26:100000:SHA256") {
                Id = 1
            };
            User user2 = new User("UserOffice", "43C39F5E14573CCB5E176B9C701673C3F7031F85C711E9A1B00AB6E4802A7310:F4C024A35DB3B92F9D1AFD928E9D6D26:100000:SHA256") {
                Id = 2
            };
            User user3 = new User("UserWarehouse", "43C39F5E14573CCB5E176B9C701673C3F7031F85C711E9A1B00AB6E4802A7310:F4C024A35DB3B92F9D1AFD928E9D6D26:100000:SHA256") {
                Id = 3,
                EmployeeWarehouseId = 1
            };
            _ = modelBuilder.Entity<User>().HasData(user1, user2, user3);


            Role adminRole = new Role("Administrateurs",
                "Administrateurs tout-puissants."
            ) {
                Id = Role.ADMIN_ROLE_ID
            };
            Role officeEmployeesRole = new Role("Employés de bureau",
                "Employés travaillant dans les bureaux de WSYS Inc."
            ) {
                Id = Role.OFFICE_EMPLOYEE_ROLE_ID
            };
            Role whEmployeeRole = new Role("Employés d'entrepôt",
                "Employés travaillant dans les entrepôts de WSYS Inc."
            ) {
                Id = Role.WAREHOUSE_EMPLOYEE_ROLE_ID
            };
            _ = modelBuilder.Entity<Role>()
                .HasData(adminRole, officeEmployeesRole, whEmployeeRole);


            // NOTE: doit être placé après l'insertion de données pour User et pour Role
            // (besoin des IDs pour les associations)
            _ = modelBuilder.Entity<User>()
                .HasMany(user => user.Roles)
                .WithMany(role => role.Users)
                .UsingEntity("UserRoles",
                    rightRelation => {
                        return rightRelation.HasOne(typeof(Role)).WithMany().HasForeignKey("RoleId").HasPrincipalKey(nameof(Role.Id));
                    },
                    leftRelation => {
                        return leftRelation.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id));
                    },
                    shadowEntityConfig => {
                        _ = shadowEntityConfig.HasKey("UserId", "RoleId");
                        _ = shadowEntityConfig.HasData(
                        new { UserId = 1, RoleId = 1 },
                        new { UserId = 2, RoleId = 2 },
                        new { UserId = 3, RoleId = 3 });
                    }
                );
            // Possiblement pas besoin de la relation inversion
            /*
            _ = modelBuilder.Entity<Role>()
                .HasMany(role => role.Users)
                .WithMany(user => user.Roles);
            */

            #endregion

        }
    }
}
