using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ComputersInventory.DAL
{
    public partial class ComputerInventoryContext : DbContext
    {
        public ComputerInventoryContext()
        {
        }

        public ComputerInventoryContext(DbContextOptions<ComputerInventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<ComputerType> ComputerTypes { get; set; }
        public virtual DbSet<ComputerTypeField> ComputerTypeFields { get; set; }
        public virtual DbSet<FormFactor> FormFactors { get; set; }
        public virtual DbSet<ScreenSize> ScreenSizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings.ComputersInventory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.ToTable("Computer");

                entity.Property(e => e.Brand).HasMaxLength(500);

                entity.Property(e => e.Processor).HasMaxLength(100);

                entity.HasOne(d => d.ComputerType)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.ComputerTypeId)
                    .HasConstraintName("FK_Computer_ComputerType");

                entity.HasOne(d => d.FormFactorNavigation)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.FormFactor)
                    .HasConstraintName("FK_Computer_FormFactor");

                entity.HasOne(d => d.ScreenSize)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.ScreenSizeId)
                    .HasConstraintName("FK_Computer_ScreenSize");
            });

            modelBuilder.Entity<ComputerType>(entity =>
            {
                entity.ToTable("ComputerType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComputerTypeField>(entity =>
            {
                entity.Property(e => e.FieldName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ComputerType)
                    .WithMany(p => p.ComputerTypeFields)
                    .HasForeignKey(d => d.ComputerTypeId)
                    .HasConstraintName("FK_ComputerTypeFields_ComputerType");
            });

            modelBuilder.Entity<FormFactor>(entity =>
            {
                entity.ToTable("FormFactor");

                entity.Property(e => e.Type).HasMaxLength(500);
            });

            modelBuilder.Entity<ScreenSize>(entity =>
            {
                entity.ToTable("ScreenSize");

                entity.Property(e => e.ScreenSize1)
                    .HasMaxLength(500)
                    .HasColumnName("ScreenSize");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
