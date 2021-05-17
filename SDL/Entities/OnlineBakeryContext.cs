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

        public virtual DbSet<Associate> Associates { get; set; }
        public virtual DbSet<Bread> Breads { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

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

            modelBuilder.Entity<Associate>(entity =>
            {
                entity.ToTable("associates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssociateLocale)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("associateLocale");

                entity.Property(e => e.AssociateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("associateName");

                entity.Property(e => e.RevaPoints).HasColumnName("revaPoints");
            });

            modelBuilder.Entity<Bread>(entity =>
            {
                entity.HasKey(e => e.BreadType)
                    .HasName("PK__Breads__2F5D7CA464EADD3A");

                entity.Property(e => e.BreadType).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.BreadCollectionNavigation)
                    .WithMany(p => p.Breads)
                    .HasForeignKey(d => d.BreadCollection)
                    .HasConstraintName("FK__Breads__BreadCol__02FC7413");
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
                    .HasName("PK__Orders__CAC5E7425E89C22C");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__00200768");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("trainers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CaffeineLevel).HasColumnName("caffeineLevel");

                entity.Property(e => e.Campus)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("campus");

                entity.Property(e => e.TrainerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("trainerName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
