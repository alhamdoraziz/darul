using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wopApi.Models
{
    public partial class wopContext : DbContext
    {
        public wopContext()
        {
        }

        public wopContext(DbContextOptions<wopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JenisKategoriTm> JenisKategoriTm { get; set; }
        public virtual DbSet<KategoriBarangJasaTm> KategoriBarangJasaTm { get; set; }
        public virtual DbSet<StatusKategoriTm> StatusKategoriTm { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=wop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.19074.3");

            modelBuilder.Entity<JenisKategoriTm>(entity =>
            {
                entity.ToTable("JenisKategori_TM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.JenisKategori)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KategoriBarangJasaTm>(entity =>
            {
                entity.HasKey(e => e.Kategori);

                entity.ToTable("KategoriBarangJasa_TM");

                entity.Property(e => e.Kategori)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateApprover).HasColumnType("datetime");

                entity.Property(e => e.DateInput).HasColumnType("datetime");

                entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Jenis)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nikapprover)
                    .HasColumnName("NIKApprover")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nikinput)
                    .HasColumnName("NIKInput")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nikupdate)
                    .HasColumnName("NIKUpdate")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusKategoriTm>(entity =>
            {
                entity.ToTable("StatusKategori_TM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
