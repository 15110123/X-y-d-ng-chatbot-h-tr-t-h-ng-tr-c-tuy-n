using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CutieShop.API.DB.Models.Entities
{
    public partial class CutieshopContext : DbContext
    {
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Auth> Auths { get; set; }
        public virtual DbSet<AuthSession> AuthSessions { get; set; }
        public virtual DbSet<Cage> Cages { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Documentation> Documentations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmpType> EmpTypes { get; set; }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<FeedingRoutine> FeedingRoutines { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodofExport> GoodofExports { get; set; }
        public virtual DbSet<GoodofImport> GoodofImports { get; set; }
        public virtual DbSet<GoodofOrder> GoodofOrders { get; set; }
        public virtual DbSet<GoodQuantity> GoodQuantities { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialofAccessory> MaterialofAccessories { get; set; }
        public virtual DbSet<MaterialofCage> MaterialofCages { get; set; }
        public virtual DbSet<MaterialofToy> MaterialofToys { get; set; }
        public virtual DbSet<MessageSession> MessageSessions { get; set; }
        public virtual DbSet<Nutrition> Nutritions { get; set; }
        public virtual DbSet<NutritionofFood> NutritionofFoods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetSize> PetSizes { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceOnlineOrder> ServiceOnlineOrders { get; set; }
        public virtual DbSet<ShipableGood> ShipableGoods { get; set; }
        public virtual DbSet<ShipableGoodofShipment> ShipableGoodofShipments { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShipStatu> ShipStatus { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=cutieshop.database.windows.net;Initial Catalog=CutieShop;User ID=shopadmin;Password=Spkt2015");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("Accessory");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Smell)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Accessory)
                    .HasForeignKey<Accessory>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Accessory_ShipableGood_Id_fk");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Accessory_Region_Id_fk");
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("Advertisement");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Advertisement_Employee_Id_fk");
            });

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.ToTable("Auth");

                entity.HasIndex(e => e.Username)
                    .HasName("Auth_Username_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImg)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthSession>(entity =>
            {
                entity.ToTable("AuthSession");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Auth)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.AuthNavigation)
                    .WithMany(p => p.AuthSessions)
                    .HasForeignKey(d => d.Auth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AuthSession_Auth_Id_fk");
            });

            modelBuilder.Entity<Cage>(entity =>
            {
                entity.ToTable("Cage");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Cage)
                    .HasForeignKey<Cage>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cage_ShipableGood_Id_fk");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Cages)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cage_Region_Id_fk");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasKey(e => new { e.MessageSession, e.Id });

                entity.ToTable("Conversation");

                entity.HasIndex(e => e.MessageSession)
                    .HasName("Conversation_MessageSession_pk")
                    .IsUnique();

                entity.Property(e => e.MessageSession)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.HasOne(d => d.MessageSessionNavigation)
                    .WithOne(p => p.Conversation)
                    .HasForeignKey<Conversation>(d => d.MessageSession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Conversation_MessageSession_Id_fk");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_Auth_Id_fk");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.ToTable("DocType");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Documentation>(entity =>
            {
                entity.ToTable("Documentation");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Htmlcontent).HasColumnName("HTMLContent");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Documentations)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documentation_Employee_Id_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Documentations)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documentation_DocType_Id_fk");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email)
                    .HasName("Employee_Email_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTown)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Store)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Auth_Id_fk");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Store_Id_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_EmpType_Id_fk");
            });

            modelBuilder.Entity<EmpType>(entity =>
            {
                entity.ToTable("EmpType");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Export>(entity =>
            {
                entity.ToTable("Export");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Store)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Exports)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Export_Employee_Id_fk");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Exports)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Export_Store_Id_fk");
            });

            modelBuilder.Entity<FeedingRoutine>(entity =>
            {
                entity.ToTable("FeedingRoutine");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Food)
                    .HasForeignKey<Food>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Food_ShipableGood_Id_fk");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Food_Region_Id_fk");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("Good");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GoodofExport>(entity =>
            {
                entity.HasKey(e => new { e.Good, e.Export });

                entity.ToTable("GoodofExport");

                entity.Property(e => e.Good)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Export)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExportNavigation)
                    .WithMany(p => p.GoodofExports)
                    .HasForeignKey(d => d.Export)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodofExport_Export_Id_fk");

                entity.HasOne(d => d.GoodNavigation)
                    .WithMany(p => p.GoodofExports)
                    .HasForeignKey(d => d.Good)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodofExport_Good_Id_fk");
            });

            modelBuilder.Entity<GoodofImport>(entity =>
            {
                entity.HasKey(e => new { e.Import, e.Good });

                entity.ToTable("GoodofImport");

                entity.Property(e => e.Import)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Good)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.GoodNavigation)
                    .WithMany(p => p.GoodofImports)
                    .HasForeignKey(d => d.Good)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodofImport_Good_Id_fk");

                entity.HasOne(d => d.ImportNavigation)
                    .WithMany(p => p.GoodofImports)
                    .HasForeignKey(d => d.Import)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodofImport_Import_Id_fk");
            });

            modelBuilder.Entity<GoodofOrder>(entity =>
            {
                entity.HasKey(e => new { e.Good, e.Order });

                entity.ToTable("GoodofOrder");

                entity.Property(e => e.Good)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Order)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.GoodNavigation)
                    .WithMany(p => p.GoodofOrders)
                    .HasForeignKey(d => d.Good)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodofOrder_Good_Id_fk");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.GoodofOrders)
                    .HasForeignKey(d => d.Order)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodofOrder_Order_Id_fk");
            });

            modelBuilder.Entity<GoodQuantity>(entity =>
            {
                entity.HasKey(e => new { e.Good, e.Store });

                entity.ToTable("GoodQuantity");

                entity.Property(e => e.Good)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Store)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.GoodNavigation)
                    .WithMany(p => p.GoodQuantities)
                    .HasForeignKey(d => d.Good)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodQuantity_Good_Id_fk");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.GoodQuantities)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GoodQuantity_Store_Id_fk");
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.ToTable("Import");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ImporterName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Import_Employee_Id_fk");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MaterialofAccessory>(entity =>
            {
                entity.HasKey(e => new { e.Material, e.Accessory });

                entity.ToTable("MaterialofAccessory");

                entity.Property(e => e.Material)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Accessory)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessoryNavigation)
                    .WithMany(p => p.MaterialofAccessories)
                    .HasForeignKey(d => d.Accessory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MaterialofAccessory_Accessory_Id_fk");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.MaterialofAccessories)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MaterialofAccessory_Material_Id_fk");
            });

            modelBuilder.Entity<MaterialofCage>(entity =>
            {
                entity.HasKey(e => new { e.Material, e.Cage });

                entity.ToTable("MaterialofCage");

                entity.Property(e => e.Material)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Cage)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.CageNavigation)
                    .WithMany(p => p.MaterialofCages)
                    .HasForeignKey(d => d.Cage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MaterialofCage_Cage_Id_fk");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.MaterialofCages)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MaterialofCage_Material_Id_fk");
            });

            modelBuilder.Entity<MaterialofToy>(entity =>
            {
                entity.HasKey(e => new { e.Material, e.Toy });

                entity.ToTable("MaterialofToy");

                entity.Property(e => e.Material)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Toy)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.MaterialofToys)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MaterialofToy_Material_Id_fk");

                entity.HasOne(d => d.ToyNavigation)
                    .WithMany(p => p.MaterialofToys)
                    .HasForeignKey(d => d.Toy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MaterialofToy_Toy_Id_fk");
            });

            modelBuilder.Entity<MessageSession>(entity =>
            {
                entity.ToTable("MessageSession");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.MessageSessions)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MessageSession_Customer_Id_fk");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.MessageSessions)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MessageSession_Employee_Id_fk");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.ToTable("Nutrition");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NutritionofFood>(entity =>
            {
                entity.HasKey(e => new { e.Nutrition, e.Food });

                entity.ToTable("NutritionofFood");

                entity.Property(e => e.Nutrition)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Food)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.FoodNavigation)
                    .WithMany(p => p.NutritionofFoods)
                    .HasForeignKey(d => d.Food)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NutritionofFood_Food_Id_fk");

                entity.HasOne(d => d.NutritionNavigation)
                    .WithMany(p => p.NutritionofFoods)
                    .HasForeignKey(d => d.Nutrition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NutritionofFood_Nutrition_Id_fk");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FeedingRoutine)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.FeedingRoutineNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.FeedingRoutine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_FeedingRoutine_Id_fk");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Pet)
                    .HasForeignKey<Pet>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pet_Good");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Size)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_PetSize_Id_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_PetType_Id_fk");
            });

            modelBuilder.Entity<PetSize>(entity =>
            {
                entity.ToTable("PetSize");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PetType>(entity =>
            {
                entity.ToTable("PetType");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => e.Customer);

                entity.ToTable("Point");

                entity.Property(e => e.Customer)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.Point)
                    .HasForeignKey<Point>(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Score_Customer_Id_fk");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.VidUrl)
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Post_Employee_Id_fk");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Pet)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Service)
                    .HasForeignKey<Service>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_Good_Id_fk");

                entity.HasOne(d => d.PetNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Pet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_Pet_Id_fk");
            });

            modelBuilder.Entity<ServiceOnlineOrder>(entity =>
            {
                entity.ToTable("ServiceOnlineOrder");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.TicketId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ServiceOnlineOrder)
                    .HasForeignKey<ServiceOnlineOrder>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ServiceOnlineOrder_Order_Id_fk");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.ServiceOnlineOrders)
                    .HasForeignKey(d => d.Service)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ServiceOnlineOrder_Service_Id_fk");
            });

            modelBuilder.Entity<ShipableGood>(entity =>
            {
                entity.ToTable("ShipableGood");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ShipableGoodofShipment>(entity =>
            {
                entity.HasKey(e => new { e.ShipableGood, e.Shipment });

                entity.ToTable("ShipableGoodofShipment");

                entity.Property(e => e.ShipableGood)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Shipment)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.ShipableGoodNavigation)
                    .WithMany(p => p.ShipableGoodofShipments)
                    .HasForeignKey(d => d.ShipableGood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ShipableGoodofShipment_ShipableGood_Id_fk");

                entity.HasOne(d => d.ShipmentNavigation)
                    .WithMany(p => p.ShipableGoodofShipments)
                    .HasForeignKey(d => d.Shipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ShipableGoodofShipment_Shipment_Id_fk");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AltAddress).HasMaxLength(200);

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ShipStatus)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Shipper)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shipment_Customer_Id_fk");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Shipment)
                    .HasForeignKey<Shipment>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shipment_Order_Id_fk");

                entity.HasOne(d => d.ShipStatusNavigation)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.ShipStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shipment_ShipStatus_Id_fk");

                entity.HasOne(d => d.ShipperNavigation)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.Shipper)
                    .HasConstraintName("Shipment_Employee_Id_fk");
            });

            modelBuilder.Entity<ShipStatu>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Manager)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Manager)
                    .HasConstraintName("Store_Employee_Id_fk");
            });

            modelBuilder.Entity<Toy>(entity =>
            {
                entity.ToTable("Toy");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Toy)
                    .HasForeignKey<Toy>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Toy_ShipableGood_Id_fk");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Toy_Region_Id_fk");
            });
        }
    }
}
