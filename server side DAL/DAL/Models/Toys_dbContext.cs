using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class Toys_dbContext : DbContext
    {
        public Toys_dbContext()
        {
        }

        public Toys_dbContext(DbContextOptions<Toys_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuydetailsTbl> BuydetailsTbls { get; set; }
        public virtual DbSet<BuyingTbl> BuyingTbls { get; set; }
        public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }
        public virtual DbSet<ToysTbl> ToysTbls { get; set; }
        public virtual DbSet<UsersTbl> UsersTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Toys_db;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<BuydetailsTbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Buydetails_tbl");

                entity.Property(e => e.Codebuy).HasColumnName("codebuy");

                entity.Property(e => e.Codetoy).HasColumnName("codetoy");

                entity.Property(e => e.Countbuy).HasColumnName("countbuy");

                entity.HasOne(d => d.CodebuyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Codebuy)
                    .HasConstraintName("FK__Buydetail__codeb__2C3393D0");

                entity.HasOne(d => d.CodetoyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Codetoy)
                    .HasConstraintName("FK__Buydetail__codet__2D27B809");
            });

            modelBuilder.Entity<BuyingTbl>(entity =>
            {
                entity.HasKey(e => e.Codebuy)
                    .HasName("PK__Buying_t__A6EF4964B6A085C3");

                entity.ToTable("Buying_tbl");

                entity.Property(e => e.Codebuy).HasColumnName("codebuy");

                entity.Property(e => e.Codeuser).HasColumnName("codeuser");

                entity.Property(e => e.Datebuy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("datebuy");

                entity.Property(e => e.Sumbuy).HasColumnName("sumbuy");

                entity.HasOne(d => d.CodeuserNavigation)
                    .WithMany(p => p.BuyingTbls)
                    .HasForeignKey(d => d.Codeuser)
                    .HasConstraintName("FK__Buying_tb__codeu__2A4B4B5E");
            });

            modelBuilder.Entity<CategoryTbl>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__79D361B68AFB0E19");

                entity.ToTable("Category_tbl");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<ToysTbl>(entity =>
            {
                entity.HasKey(e => e.Codetoy)
                    .HasName("PK__Toys_tbl__42C6B766774A4DBE");

                entity.ToTable("Toys_tbl");

                entity.Property(e => e.Codetoy).HasColumnName("codetoy");

                entity.Property(e => e.Codecategory).HasColumnName("codecategory");

                entity.Property(e => e.Describetoy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("describetoy");

                entity.Property(e => e.Nametoy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nametoy");

                entity.Property(e => e.Picture)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.CodecategoryNavigation)
                    .WithMany(p => p.ToysTbls)
                    .HasForeignKey(d => d.Codecategory)
                    .HasConstraintName("FK__Toys_tbl__codeca__25869641");
            });

            modelBuilder.Entity<UsersTbl>(entity =>
            {
                entity.HasKey(e => e.Codeuser)
                    .HasName("PK__Users_tb__85AB51E5C873C4B5");

                entity.ToTable("Users_tbl");

                entity.Property(e => e.Codeuser).HasColumnName("codeuser");

                entity.Property(e => e.Addressuser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("addressuser");

                entity.Property(e => e.Nameuser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nameuser");

                entity.Property(e => e.Passworduser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("passworduser");

                entity.Property(e => e.Phoneuser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phoneuser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
