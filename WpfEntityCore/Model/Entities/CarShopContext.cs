using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class CarShopContext : DbContext
    {
        public CarShopContext()
        {
        }

        public CarShopContext(DbContextOptions<CarShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarRegionNumber> CarRegionNumbers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserHasCar> UserHasCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=32-1\\SQLEXPRESS;Database=CarShop;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RegionId, e.CityId, e.StreetId });

                entity.ToTable("Address");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RegionId)
                    .HasMaxLength(3)
                    .HasColumnName("RegionID")
                    .IsFixedLength(true);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_City");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Region");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Street");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_User");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarModel).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.ManufactureDate).HasColumnType("date");

                entity.Property(e => e.Mark).HasMaxLength(50);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<CarRegionNumber>(entity =>
            {
                entity.HasKey(e => new { e.RegionNumberId, e.CarId });

                entity.ToTable("CarRegionNumber");

                entity.Property(e => e.RegionNumberId)
                    .HasMaxLength(3)
                    .HasColumnName("RegionNumberID")
                    .IsFixedLength(true);

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarRegionNumbers)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarRegionNumber_Car");

                entity.HasOne(d => d.RegionNumber)
                    .WithMany(p => p.CarRegionNumbers)
                    .HasForeignKey(d => d.RegionNumberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarRegionNumber_Region");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(80);
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.ContractNum)
                    .HasName("PK__Contract__520E976ADE72748C");

                entity.ToTable("Contract");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Сonsideration).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Car");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Region__3214EC276F3CC8C9");

                entity.ToTable("Region");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(80);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(80);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("Street");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(80);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.MidleName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserHasCar>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CarId })
                    .HasName("PK_UserHasCar_1");

                entity.ToTable("UserHasCar");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.UserHasCars)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserHasCar_Car");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHasCars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserHasCar_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
