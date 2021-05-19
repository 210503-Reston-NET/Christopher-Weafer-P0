using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SDL.Entities
{
    public partial class OnlineBakeryContext : DbContext
    {
        public OnlineBakeryContext()
        {
        }

        public OnlineBakeryContext(DbContextOptions<OnlineBakeryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bakery> Bakeries { get; set; }
        public virtual DbSet<BakeryInventory> BakeryInventories { get; set; }
        public virtual DbSet<Bread> Breads { get; set; }
        public virtual DbSet<BreadBatch> BreadBatches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:online-bakery.database.windows.net,1433;Initial Catalog=Online-Bakery;Persist Security Info=False;User ID=CWeafer;Password=Breadbase1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bakery>(entity =>
            {
                entity.HasKey(e => e.BakeId)
                    .HasName("PK__Bakery__876B1A9E00D6968F");

                entity.ToTable("Bakery");

                entity.Property(e => e.BakeId).HasColumnName("bakeID");

                entity.Property(e => e.BakeryName)
                    .HasMaxLength(50)
                    .HasColumnName("bakeryName");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<BakeryInventory>(entity =>
            {
                entity.ToTable("BakeryInventory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BakeryInventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__BakeryInv__Produ__3C34F16F");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.BakeryInventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__BakeryInv__Store__3D2915A8");
            });

            modelBuilder.Entity<Bread>(entity =>
            {
                entity.HasKey(e => e.BreadCode)
                    .HasName("PK__Bread__AA2EF96091C50D0F");

                entity.ToTable("Bread");

                entity.Property(e => e.BreadType).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<BreadBatch>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("PK__BreadBat__5D55CE386EA0249E");

                entity.ToTable("BreadBatch");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BreadBatches)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__BreadBatc__Order__2FCF1A8A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BreadBatches)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__BreadBatc__Produ__30C33EC3");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber)
                    .HasName("PK__Orders__CAC5E742534BA487");

                entity.Property(e => e.BakeryId).HasColumnName("bakeryID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.HasOne(d => d.Bakery)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BakeryId)
                    .HasConstraintName("FK__Orders__bakeryID__2CF2ADDF");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__2BFE89A6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
