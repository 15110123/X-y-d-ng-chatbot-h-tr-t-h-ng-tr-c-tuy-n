using Microsoft.EntityFrameworkCore;

namespace CutieShop.Models.Entities
{
    public partial class CutieshopContext : DbContext
    {
        public CutieshopContext()
        {
        }

        public CutieshopContext(DbContextOptions<CutieshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessory> Accessory { get; set; }
        public virtual DbSet<Auth> Auth { get; set; }
        public virtual DbSet<Cage> Cage { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmpRole> EmpRole { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<JoinXx> JoinXx { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<NhapTrongKy> NhapTrongKy { get; set; }
        public virtual DbSet<Nutrition> Nutrition { get; set; }
        public virtual DbSet<OnlineOrder> OnlineOrder { get; set; }
        public virtual DbSet<OnlineOrderProduct> OnlineOrderProduct { get; set; }
        public virtual DbSet<Origin> Origin { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetType> PetType { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductForPetType> ProductForPetType { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportDetails> ReportDetails { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceOnlineOrder> ServiceOnlineOrder { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TonCuoiKy> TonCuoiKy { get; set; }
        public virtual DbSet<TonDauKy> TonDauKy { get; set; }
        public virtual DbSet<Toy> Toy { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPoint> UserPoint { get; set; }
        public virtual DbSet<UserPointHistory> UserPointHistory { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<XuatTrongKy> XuatTrongKy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=cutieshop.database.windows.net;Initial Catalog=CutieShop;Persist Security Info=True;User ID=shopadmin;Password=Spkt2015");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialId)
                    .IsRequired()
                    .HasColumnName("MaterialID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OriginId)
                    .IsRequired()
                    .HasColumnName("OriginID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Smell).HasMaxLength(50);

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Accessory)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accessory_Material");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Accessory)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accessory_Origin");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Accessory)
                    .HasForeignKey<Accessory>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accessory_Product");
            });

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Cage>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialId)
                    .IsRequired()
                    .HasColumnName("MaterialID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OriginId)
                    .IsRequired()
                    .HasColumnName("OriginID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Cage)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cage_Material");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Cage)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cage_Origin");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Cage)
                    .HasForeignKey<Cage>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cage_Product");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Employee_EmpRole");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Auth");
            });

            modelBuilder.Entity<EmpRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NutritionId)
                    .IsRequired()
                    .HasColumnName("NutritionID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OriginId)
                    .IsRequired()
                    .HasColumnName("OriginID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Nutrition)
                    .WithMany(p => p.Food)
                    .HasForeignKey(d => d.NutritionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Food_Nutrition");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Food)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Food_Origin");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Food)
                    .HasForeignKey<Food>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Food_Product");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchAddress).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Invoice_User");
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasKey(e => e.InvoiceDetailId);

                entity.Property(e => e.InvoiceDetailId)
                    .HasColumnName("InvoiceDetailID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InvoiceId)
                    .IsRequired()
                    .HasColumnName("InvoiceID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Invoice");
            });

            modelBuilder.Entity<JoinXx>(entity =>
            {
                entity.HasKey(e => e.IdJoin);

                entity.ToTable("JoinXX");

                entity.Property(e => e.IdJoin)
                    .HasColumnName("ID_Join")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdNtk)
                    .HasColumnName("ID_NTK")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdReport)
                    .HasColumnName("ID_Report")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdTck)
                    .HasColumnName("ID_TCK")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdTdk)
                    .HasColumnName("ID_TDK")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdXtk)
                    .HasColumnName("ID_XTK")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJoinNavigation)
                    .WithOne(p => p.JoinXx)
                    .HasPrincipalKey<ReportDetails>(p => p.IdJoin)
                    .HasForeignKey<JoinXx>(d => d.IdJoin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JoinXX_Report_Details_ID_Join_fk");

                entity.HasOne(d => d.IdNtkNavigation)
                    .WithMany(p => p.JoinXx)
                    .HasForeignKey(d => d.IdNtk)
                    .HasConstraintName("FK_JoinXX_NhapTrongKy");

                entity.HasOne(d => d.IdReportNavigation)
                    .WithMany(p => p.JoinXx)
                    .HasForeignKey(d => d.IdReport)
                    .HasConstraintName("FK_JoinXX_Report");

                entity.HasOne(d => d.IdTckNavigation)
                    .WithMany(p => p.JoinXx)
                    .HasForeignKey(d => d.IdTck)
                    .HasConstraintName("FK_JoinXX_TonCuoiKy");

                entity.HasOne(d => d.IdTdkNavigation)
                    .WithMany(p => p.JoinXx)
                    .HasForeignKey(d => d.IdTdk)
                    .HasConstraintName("FK_JoinXX_TonDauKy");

                entity.HasOne(d => d.IdXtkNavigation)
                    .WithMany(p => p.JoinXx)
                    .HasForeignKey(d => d.IdXtk)
                    .HasConstraintName("FK_JoinXX_XuatTrongKy");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.MaterialId)
                    .HasColumnName("MaterialID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhapTrongKy>(entity =>
            {
                entity.HasKey(e => e.IdNtk);

                entity.Property(e => e.IdNtk)
                    .HasColumnName("ID_NTK")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.QuantityNtk).HasColumnName("Quantity_NTK");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.Property(e => e.NutritionId)
                    .HasColumnName("NutritionID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OnlineOrder>(entity =>
            {
                entity.Property(e => e.OnlineOrderId)
                    .HasColumnName("OnlineOrderID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OnlineOrder)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineOrder_Status");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.OnlineOrder)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineOrder_User");
            });

            modelBuilder.Entity<OnlineOrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OnlineOrderId, e.ProductId });

                entity.Property(e => e.OnlineOrderId)
                    .HasColumnName("OnlineOrderID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.OnlineOrder)
                    .WithMany(p => p.OnlineOrderProduct)
                    .HasForeignKey(d => d.OnlineOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineOrderProduct_OnlineOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OnlineOrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineOrderProduct_Product");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.Property(e => e.OriginId)
                    .HasColumnName("OriginID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PetTypeId)
                    .IsRequired()
                    .HasColumnName("PetTypeID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.SizeId)
                    .IsRequired()
                    .HasColumnName("SizeID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.PetType)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.PetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pet_PetType");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Pet)
                    .HasForeignKey<Pet>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pet_Product");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pet_Size");
            });

            modelBuilder.Entity<PetType>(entity =>
            {
                entity.Property(e => e.PetTypeId)
                    .HasColumnName("PetTypeID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasColumnName("VendorID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Vendor");
            });

            modelBuilder.Entity<ProductForPetType>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.PetTypeId });

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PetTypeId)
                    .HasColumnName("PetTypeID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.PetType)
                    .WithMany(p => p.ProductForPetType)
                    .HasForeignKey(d => d.PetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductForPetType_PetType");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductForPetType)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductForPetType_Product");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.IdReport);

                entity.Property(e => e.IdReport)
                    .HasColumnName("ID_Report")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateElWarehouse)
                    .HasColumnName("Date_El_warehouse")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ReportDetails>(entity =>
            {
                entity.ToTable("Report_Details");

                entity.HasIndex(e => e.IdJoin)
                    .HasName("Report_Details_ID_Join_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.IdProduct)
                    .HasName("Report_Details_ID_Product_pk_2")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdJoin)
                    .IsRequired()
                    .HasColumnName("ID_Join")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdProduct)
                    .HasColumnName("ID_Product")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Service)
                    .HasForeignKey<Service>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Product");
            });

            modelBuilder.Entity<ServiceOnlineOrder>(entity =>
            {
                entity.Property(e => e.ServiceOnlineOrderId)
                    .HasColumnName("ServiceOnlineOrderID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PetId)
                    .IsRequired()
                    .HasColumnName("PetID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.ServiceOnlineOrderNavigation)
                    .WithOne(p => p.ServiceOnlineOrder)
                    .HasForeignKey<ServiceOnlineOrder>(d => d.ServiceOnlineOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceOnlineOrder_OnlineOrder");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Session_Auth");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeId)
                    .HasColumnName("SizeID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TonCuoiKy>(entity =>
            {
                entity.HasKey(e => e.IdTck);

                entity.Property(e => e.IdTck)
                    .HasColumnName("ID_TCK")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.QuantityTck).HasColumnName("Quantity_TCK");
            });

            modelBuilder.Entity<TonDauKy>(entity =>
            {
                entity.HasKey(e => e.IdTdk);

                entity.Property(e => e.IdTdk)
                    .HasColumnName("ID_TDK")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.QuantityTdk).HasColumnName("Quantity_TDK");
            });

            modelBuilder.Entity<Toy>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialId)
                    .IsRequired()
                    .HasColumnName("MaterialID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OriginId)
                    .IsRequired()
                    .HasColumnName("OriginID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Toy)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Toy_Material");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Toy)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Toy_Origin");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Toy)
                    .HasForeignKey<Toy>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Toy_Product");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FacebookId)
                    .HasColumnName("FacebookID")
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Auth");
            });

            modelBuilder.Entity<UserPoint>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.UserPoint)
                    .HasForeignKey<UserPoint>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPoint_User");
            });

            modelBuilder.Entity<UserPointHistory>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.OnlineOrderId });

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OnlineOrderId)
                    .HasColumnName("OnlineOrderID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserPointHistory)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPointHistory_User");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorId)
                    .HasColumnName("VendorID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<XuatTrongKy>(entity =>
            {
                entity.HasKey(e => e.IdXtk);

                entity.Property(e => e.IdXtk)
                    .HasColumnName("ID_XTK")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.QuantityXtk).HasColumnName("Quantity_XTK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
