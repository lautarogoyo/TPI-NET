using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<DocenteCurso> DocentesCursos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Materia> Materias { get; set; }         // ✅ NUEVO
        public DbSet<Comision> Comisiones { get; set; }       // ✅ NUEVO

        public TPIContext()
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
                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso)
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

                // Evitar cursos duplicados para la misma comision + materia + año
                entity.HasIndex(e => new { e.IDComision, e.IDMateria, e.AnioCalendario })
                      .IsUnique();
            });

            // --- DOCENTE CURSO ---
            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.ToTable("DocentesCursos");

                entity.HasKey(dc => new { dc.IDCurso, dc.IDDocente });

                entity.Property(dc => dc.Cargo)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20);

                entity.HasOne(dc => dc.Curso)
                      .WithMany(c => c.DocenteCursos)
                      .HasForeignKey(dc => dc.IDCurso)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(dc => new { dc.IDCurso, dc.IDDocente })
                      .IsUnique();
            });

            // --- PERSONA ---
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(p => p.IDPersona);

                entity.Property(p => p.IDPersona)
                      .ValueGeneratedOnAdd();

                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Apellido)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Direccion)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Email)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Telefono)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.FechaNac)
                      .IsRequired();

                entity.Property(p => p.Legajo)
                      .IsRequired();

                entity.Property(p => p.TipoPersona)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.IDPlan)
                      .IsRequired();

                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(p => p.IDPlan)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- PLAN ---
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(p => p.IDPlan);

                entity.Property(p => p.IDPlan)
                      .ValueGeneratedOnAdd();

                entity.Property(p => p.DescPlan)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.IDEspecialidad)
                      .IsRequired();

                entity.HasOne<Especialidad>()
                      .WithMany()
                      .HasForeignKey(p => p.IDEspecialidad)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- MATERIA --- ✅ NUEVO
            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(m => m.IDMateria);

                entity.Property(m => m.IDMateria)
                      .ValueGeneratedOnAdd();

                entity.Property(m => m.Descripcion)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(m => m.HSSemanales)
                      .IsRequired();

                entity.Property(m => m.HSTotales)
                      .IsRequired();

                entity.Property(m => m.IDPlan)
                      .IsRequired();

                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(m => m.IDPlan)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- COMISION --- ✅ NUEVO
            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(c => c.IDComision);

                entity.Property(c => c.IDComision)
                      .ValueGeneratedOnAdd();

                entity.Property(c => c.Descripcion)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.AnioEspecialidad)
                      .IsRequired();

                entity.Property(c => c.IDPlan)
                      .IsRequired();

                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(c => c.IDPlan)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
