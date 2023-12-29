using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TranQuocTrung1.Entities
{
    public partial class ROCKERContext : DbContext
    {
        public ROCKERContext()
        {
        }

        public ROCKERContext(DbContextOptions<ROCKERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arrival> Arrivals { get; set; } = null!;
        public virtual DbSet<AuthUser> AuthUsers { get; set; } = null!;
        public virtual DbSet<Berth> Berths { get; set; } = null!;
        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<CargoDetail> CargoDetails { get; set; } = null!;
        public virtual DbSet<Departure> Departures { get; set; } = null!;
        public virtual DbSet<Finance> Finances { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<GoMap> GoMaps { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<Harbor> Harbors { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<PhanLoai> PhanLoais { get; set; } = null!;
        public virtual DbSet<ResponseObject> ResponseObjects { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<Ship> Ships { get; set; } = null!;
        public virtual DbSet<SortShip> SortShips { get; set; } = null!;
        public virtual DbSet<TrainSchedule> TrainSchedules { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-OP4RDR2O;Initial Catalog=ROCKER;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arrival>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnType("date")
                    .HasColumnName("arrivalDate");

                entity.Property(e => e.ArrivalTime).HasColumnName("arrivalTime");

                entity.Property(e => e.BerthId).HasColumnName("berthId");

                entity.Property(e => e.ShipId).HasColumnName("shipId");

                entity.HasOne(d => d.Berth)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.BerthId)
                    .HasConstraintName("FK__Arrivals__berthI__412EB0B6");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.ShipId)
                    .HasConstraintName("FK__Arrivals__shipId__403A8C7D");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__AuthUser__F3DBC572B04F12A3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Berth>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BerthCapacity).HasColumnName("berthCapacity");

                entity.Property(e => e.BerthName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("berthName");

                entity.Property(e => e.BerthStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("berthStatus");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CargoDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cargoDesc");

                entity.Property(e => e.ShipId).HasColumnName("shipId");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.ShipId)
                    .HasConstraintName("FK__Cargos__shipId__36B12243");
            });

            modelBuilder.Entity<CargoDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CargoEnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cargoEnd");

                entity.Property(e => e.CargoEndDate)
                    .HasColumnType("date")
                    .HasColumnName("cargoEndDate");

                entity.Property(e => e.CargoEndTime).HasColumnName("cargoEndTime");

                entity.Property(e => e.CargoId).HasColumnName("cargoId");

                entity.Property(e => e.CargoQuantity).HasColumnName("cargoQuantity");

                entity.Property(e => e.CargoStart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cargoStart");

                entity.Property(e => e.CargoStartDate)
                    .HasColumnType("date")
                    .HasColumnName("cargoStartDate");

                entity.Property(e => e.CargoStartTime).HasColumnName("cargoStartTime");

                entity.Property(e => e.CargoType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cargoType");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.CargoDetails)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("FK__CargoDeta__cargo__440B1D61");
            });

            modelBuilder.Entity<Departure>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BerthId).HasColumnName("berthId");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("date")
                    .HasColumnName("departureDate");

                entity.Property(e => e.DepartureTime).HasColumnName("departureTime");

                entity.Property(e => e.ShipId).HasColumnName("shipId");

                entity.HasOne(d => d.Berth)
                    .WithMany(p => p.Departures)
                    .HasForeignKey(d => d.BerthId)
                    .HasConstraintName("FK__Departure__berth__3D5E1FD2");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.Departures)
                    .HasForeignKey(d => d.ShipId)
                    .HasConstraintName("FK__Departure__shipI__3C69FB99");
            });

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.ToTable("Finance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bill)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bill");

                entity.Property(e => e.MovinContract)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("movinContract");

                entity.Property(e => e.Pay)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("pay");

                entity.Property(e => e.PortFee)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("portFee");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.ToTable("GioHang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SanPhamId).HasColumnName("sanPhamId");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK__GioHang__sanPham__4BAC3F29");
            });

            modelBuilder.Entity<GoMap>(entity =>
            {
                entity.ToTable("GoMap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameGoMapDnb)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameGoMapDNB");

                entity.Property(e => e.NameGoMapMttn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameGoMapMTTN");

                entity.Property(e => e.NameGoMapTnb)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameGoMapTNB");

                entity.Property(e => e.NameGoMapTphcm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameGoMapTPHCM");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GoodsName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("goodsName");
            });

            modelBuilder.Entity<Harbor>(entity =>
            {
                entity.ToTable("Harbor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ability).HasColumnName("ability");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Time)
                    .HasColumnType("date")
                    .HasColumnName("time");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fileName");
            });

            modelBuilder.Entity<PhanLoai>(entity =>
            {
                entity.ToTable("PhanLoai");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TenLoai)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tenLoai");
            });

            modelBuilder.Entity<ResponseObject>(entity =>
            {
                entity.ToTable("ResponseObject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("data");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiaBan)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("giaBan");

                entity.Property(e => e.HinhSanPham)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hinhSanPham");

                entity.Property(e => e.MoTaSanPham)
                    .HasColumnType("text")
                    .HasColumnName("moTaSanPham");

                entity.Property(e => e.NgayThemVao)
                    .HasColumnType("date")
                    .HasColumnName("ngayThemVao");

                entity.Property(e => e.PhanLoaiId).HasColumnName("phanLoaiId");

                entity.Property(e => e.TenSanPham)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tenSanPham");

                entity.HasOne(d => d.PhanLoai)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.PhanLoaiId)
                    .HasConstraintName("FK__SanPham__phanLoa__48CFD27E");
            });

            modelBuilder.Entity<Ship>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ShipAuthInfo).HasColumnName("shipAuthInfo");

                entity.Property(e => e.ShipCheckIn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shipCheckIn");

                entity.Property(e => e.ShipImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("shipImage");

                entity.Property(e => e.ShipName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("shipName");

                entity.Property(e => e.ShipNameAuth)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("shipNameAuth");

                entity.Property(e => e.ShipNationality)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shipNationality");

                entity.Property(e => e.ShipPlate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("shipPlate");

                entity.Property(e => e.ShipSize)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("shipSize");

                entity.Property(e => e.ShipWattage)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("shipWattage");

                entity.Property(e => e.ShipWeight)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("shipWeight");
            });

            modelBuilder.Entity<SortShip>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BerthId).HasColumnName("berthId");

                entity.Property(e => e.LocationBerth).HasColumnName("locationBerth");

                entity.Property(e => e.ShipId).HasColumnName("shipId");

                entity.HasOne(d => d.Berth)
                    .WithMany(p => p.SortShips)
                    .HasForeignKey(d => d.BerthId)
                    .HasConstraintName("FK__SortShips__berth__5165187F");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.SortShips)
                    .HasForeignKey(d => d.ShipId)
                    .HasConstraintName("FK__SortShips__shipI__5070F446");
            });

            modelBuilder.Entity<TrainSchedule>(entity =>
            {
                entity.ToTable("TrainSchedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeparturePort).HasColumnName("departurePort");

                entity.Property(e => e.DestinationPort).HasColumnName("destinationPort");

                entity.Property(e => e.ShipsId).HasColumnName("shipsId");

                entity.Property(e => e.TimeIn)
                    .HasColumnType("datetime")
                    .HasColumnName("timeIn");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("datetime")
                    .HasColumnName("timeOut");

                entity.HasOne(d => d.Ships)
                    .WithMany(p => p.TrainSchedules)
                    .HasForeignKey(d => d.ShipsId)
                    .HasConstraintName("FK__TrainSche__ships__398D8EEE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E616457F556F2")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572B321DBC5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
