using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoVueling.Models
{
    public partial class DesaprendiendoDBContext : DbContext
    {
        public DesaprendiendoDBContext()
        {
        }

        public DesaprendiendoDBContext(DbContextOptions<DesaprendiendoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoAmedida> CursoAmedida { get; set; }
        public virtual DbSet<CursoImpartido> CursoImpartido { get; set; }
        public virtual DbSet<Lección> Lección { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<ModulosCursoAmedida> ModulosCursoAmedida { get; set; }
        public virtual DbSet<ModulosCursoCerrado> ModulosCursoCerrado { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:desaprendiendodb.database.windows.net,1433;Initial Catalog=desaprendiendoDB;Persist Security Info=False;User ID=jacintoaisa;Password=kz8tnzkz!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Categoria1)
                    .HasColumnName("Categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComentarioHtml).HasColumnName("ComentarioHTML");

                entity.Property(e => e.ImagenGrande)
                    .HasColumnName("Imagen Grande")
                    .HasColumnType("image");

                entity.Property(e => e.ImagenMiniatura)
                    .HasColumnName("Imagen Miniatura")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PosicionGeodesica)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.ComentarioHtml).HasColumnName("Comentario HTML");

                entity.Property(e => e.Curso1)
                    .HasColumnName("Curso")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImagenGrande)
                    .HasColumnName("Imagen Grande")
                    .HasColumnType("image");

                entity.Property(e => e.ImagenMiniatura)
                    .HasColumnName("Imagen Miniatura")
                    .HasColumnType("image");

                entity.HasOne(d => d.SubCategoriaNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.SubCategoria)
                    .HasConstraintName("FK_Curso_SubCategoria");
            });

            modelBuilder.Entity<CursoAmedida>(entity =>
            {
                entity.ToTable("CursoAMedida");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCreación)
                    .HasColumnName("Fecha Creación")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CursoImpartido>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CursoImpartido)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_CursoImpartido_Cliente");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursoImpartido)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK_CursoImpartido_Curso");
            });

            modelBuilder.Entity<Lección>(entity =>
            {
                entity.Property(e => e.ComentarioHtml).HasColumnName("Comentario HTML");

                entity.Property(e => e.HayEjercicios).HasColumnName("Hay Ejercicios");

                entity.Property(e => e.Lección1)
                    .HasColumnName("Lección")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModuloNavigation)
                    .WithMany(p => p.Lección)
                    .HasForeignKey(d => d.Modulo)
                    .HasConstraintName("FK_Lección_Modulo");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ComentarioHtml).HasColumnName("Comentario HTML");

                entity.Property(e => e.DuracionEnMinutos).HasColumnName("Duracion en Minutos");

                entity.Property(e => e.HayEjercicios).HasColumnName("Hay Ejercicios");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Modulo1)
                    .HasColumnName("Modulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.Modulo)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK_Modulo_Curso");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Modulo)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_Modulo_Profesor");
            });

            modelBuilder.Entity<ModulosCursoAmedida>(entity =>
            {
                entity.ToTable("ModulosCursoAMedida");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCursoAmedida).HasColumnName("IdCursoAMedida");

                entity.Property(e => e.IdModuloAmedida).HasColumnName("IdModuloAMedida");

                entity.HasOne(d => d.IdCursoAmedidaNavigation)
                    .WithMany(p => p.ModulosCursoAmedida)
                    .HasForeignKey(d => d.IdCursoAmedida)
                    .HasConstraintName("FK_ModulosCursoAMedida_CursoAMedida");

                entity.HasOne(d => d.IdModuloAmedidaNavigation)
                    .WithMany(p => p.ModulosCursoAmedida)
                    .HasForeignKey(d => d.IdModuloAmedida)
                    .HasConstraintName("FK_ModulosCursoAMedida_Modulo");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.ModulosCursoAmedida)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_ModulosCursoAMedida_Profesor");
            });

            modelBuilder.Entity<ModulosCursoCerrado>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCursoCerrado).HasColumnName("idCursoCerrado");

                entity.Property(e => e.IdModuloCerrado).HasColumnName("idModuloCerrado");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(d => d.IdCursoCerradoNavigation)
                    .WithMany(p => p.ModulosCursoCerrado)
                    .HasForeignKey(d => d.IdCursoCerrado)
                    .HasConstraintName("FK_ModulosCursoCerrado_Curso");

                entity.HasOne(d => d.IdModuloCerradoNavigation)
                    .WithMany(p => p.ModulosCursoCerrado)
                    .HasForeignKey(d => d.IdModuloCerrado)
                    .HasConstraintName("FK_ModulosCursoCerrado_Modulo");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("image");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategoria>(entity =>
            {
                entity.Property(e => e.ComentarioHtml).HasColumnName("ComentarioHTML");

                entity.Property(e => e.ImagenGrande)
                    .HasColumnName("Imagen Grande")
                    .HasColumnType("image");

                entity.Property(e => e.ImagenMiniatura)
                    .HasColumnName("Imagen Miniatura")
                    .HasColumnType("image");

                entity.Property(e => e.SubCategoria1)
                    .HasColumnName("Sub Categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.SubCategoria)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK_SubCategoria_Categoria");
            });
        }
    }
}
