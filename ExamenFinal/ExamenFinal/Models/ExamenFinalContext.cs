using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExamenFinal.Models
{
    public partial class ExamenFinalContext : DbContext
    {
        public ExamenFinalContext()
        {
        }

        public ExamenFinalContext(DbContextOptions<ExamenFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCatedratico> TblCatedraticos { get; set; }
        public virtual DbSet<TblCurso> TblCursos { get; set; }
        public virtual DbSet<TblStatus> TblStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SUGA7\\SQLEXPRESS;Initial Catalog=ExamenFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCatedratico>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("tbl_catedratico");

                entity.Property(e => e.CatId).HasColumnName("cat_ID");

                entity.Property(e => e.CatApellido)
                    .HasMaxLength(50)
                    .HasColumnName("cat_Apellido")
                    .IsFixedLength(true);

                entity.Property(e => e.CatCorreo)
                    .HasMaxLength(200)
                    .HasColumnName("cat_Correo")
                    .IsFixedLength(true);

                entity.Property(e => e.CatNombre)
                    .HasMaxLength(50)
                    .HasColumnName("cat_Nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.CatStatus)
                    .HasMaxLength(20)
                    .HasColumnName("cat_status")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblCurso>(entity =>
            {
                entity.HasKey(e => e.CursoId);

                entity.ToTable("tbl_curso");

                entity.Property(e => e.CursoId).HasColumnName("curso_ID");

                entity.Property(e => e.CursoNombre)
                    .HasMaxLength(50)
                    .HasColumnName("curso_Nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("tbl_status");

                entity.Property(e => e.StatusId).HasColumnName("status_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .IsFixedLength(true);

                entity.Property(e => e.StatusCat).HasColumnName("status_cat");

                entity.Property(e => e.StatusCurs).HasColumnName("status_curs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
