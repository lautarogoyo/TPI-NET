using System.Reflection.Emit;
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
        public DbSet<Materia> Materias { get; set; }         
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<ModuloUsuario> ModulosUsuarios { get; set; }
        public DbSet<AlumnoInscripcion> AlumnosInscripciones { get; set; }



        public TPIContext(DbContextOptions<TPIContext> options) : base(options) { }

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

                /*
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
                */
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


            // --- USUARIO ---
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasKey(u => u.IDUsuario);

                entity.Property(u => u.IDUsuario)
                      .ValueGeneratedOnAdd();

                entity.Property(u => u.NombreUsuario)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.Clave)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.Habilitado)
                      .IsRequired();

                entity.Property(u => u.IDPersona)
                      .IsRequired();

                entity.HasOne<Persona>()
                      .WithMany()
                      .HasForeignKey(u => u.IDPersona)
                      .OnDelete(DeleteBehavior.Restrict);
            });



            // --- MODULO ---
            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("modulos");

                entity.HasKey(m => m.IDModulo);

                entity.Property(m => m.IDModulo)
                      .ValueGeneratedOnAdd();

                entity.Property(m => m.DescModulo)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(m => m.Ejecuta)
                      .IsRequired()
                      .HasMaxLength(50);
            });


            // --- MODULOS_USUARIOS ---
            modelBuilder.Entity<ModuloUsuario>(entity =>
            {
                entity.ToTable("modulos_usuarios");

                entity.HasKey(mu => mu.IDModuloUsuario);

                entity.Property(mu => mu.IDModuloUsuario)
                      .ValueGeneratedOnAdd();

                entity.Property(mu => mu.IDModulo).IsRequired();
                entity.Property(mu => mu.IDUsuario).IsRequired();
                entity.Property(mu => mu.Alta).IsRequired();
                entity.Property(mu => mu.Baja).IsRequired();
                entity.Property(mu => mu.Modificacion).IsRequired();
                entity.Property(mu => mu.Consulta).IsRequired();

                entity.HasOne<Usuario>()
                      .WithMany()
                      .HasForeignKey(mu => mu.IDUsuario)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Modulo>()
                      .WithMany()
                      .HasForeignKey(mu => mu.IDModulo)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // --- ALUMNOS_INSCRIPCIONES ---
            modelBuilder.Entity<AlumnoInscripcion>(entity =>
            {
                entity.ToTable("alumnos_inscripciones");

                entity.HasKey(ai => ai.IDInscripcion);

                entity.Property(ai => ai.IDInscripcion)
                      .ValueGeneratedOnAdd();

                entity.Property(ai => ai.IDAlumno).IsRequired();
                entity.Property(ai => ai.IDCurso).IsRequired();
                entity.Property(ai => ai.Condicion)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(ai => ai.Nota).IsRequired();

                entity.HasOne<Persona>()
                      .WithMany()
                      .HasForeignKey(ai => ai.IDAlumno)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Curso>()
                      .WithMany()
                      .HasForeignKey(ai => ai.IDCurso)
                      .OnDelete(DeleteBehavior.Restrict);
            });





        }
    }
}
