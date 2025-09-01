using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<DocenteCurso> DocentesCursos { get; set; }

        internal TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- ESPECIALIDAD ---
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IDEspecialidad);

                entity.Property(e => e.IDEspecialidad)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // --- CURSO ---
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.AnioCalendario)
                      .IsRequired();

                entity.Property(e => e.Cupo)
                      .IsRequired();

                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.IDComision)
                      .IsRequired();

                entity.Property(e => e.IDMateria)
                      .IsRequired();

                // (Opcional) evitar cursos duplicados para la misma comision + materia + año
                entity.HasIndex(e => new { e.IDComision, e.IDMateria, e.AnioCalendario })
                      .IsUnique();
            });

            // --- DOCENTE CURSO ---
            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.ToTable("DocentesCursos");

                // PK compuesta
                entity.HasKey(dc => new { dc.IDCurso, dc.IDDocente });

                entity.Property(dc => dc.Cargo)
                      .IsRequired()
                      .HasConversion<string>() // guarda enum como string
                      .HasMaxLength(20);

                // FK a Curso
                entity.HasOne(dc => dc.Curso)
                      .WithMany(c => c.DocenteCursos)
                      .HasForeignKey(dc => dc.IDCurso)
                      .OnDelete(DeleteBehavior.Restrict);

                // Si tenés una clase Persona con Docencias, podés agregar esto:
                // entity.HasOne(dc => dc.Docente)
                //       .WithMany(p => p.Docencias)
                //       .HasForeignKey(dc => dc.IDDocente)
                //       .OnDelete(DeleteBehavior.Restrict);

                // Para evitar que un docente se repita en el mismo curso
                entity.HasIndex(dc => new { dc.IDCurso, dc.IDDocente })
                      .IsUnique();
            });
        }
    }
}
