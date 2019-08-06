using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.DataAccess.Entities
{
    public partial class Project1DbContext : DbContext
    {
        public Project1DbContext()
        {
        }

        public Project1DbContext(DbContextOptions<Project1DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<OrderHistoryDetail> OrderHistoryDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "sales");

                entity.HasIndex(e => new { e.X, e.Y })
                    .HasName("UQ_Address_Customer")
                    .IsUnique();

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "sales");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_LocationId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "sales");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_StoreId");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderHis__C3905BCFE35CAA6C");

                entity.ToTable("OrderHistory", "sales");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CustomerId");

                entity.HasOne(d => d.location)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_LocationId_OrderHistory");
            });

            modelBuilder.Entity<OrderHistoryDetail>(entity =>
            {
                entity.ToTable("OrderHistoryDetail", "sales");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Price]*[Quantity])");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistoryDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHistory_OrderId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "sales");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "sales");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Store__737584F6DACC5A85")
                    .IsUnique();

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rules).HasMaxLength(250);
            });
        }
    }
}
