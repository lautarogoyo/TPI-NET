using System.Reflection.Emit;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            modelBuilder.Entity<Especialidad>(e =>
            {
                e.HasKey(x => x.IDEspecialidad);
                e.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            });

            // --- CURSOS ---
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("cursos");

                // PK
                entity.HasKey(e => e.IdCurso)
                      .HasName("PK_Cursos");

                entity.Property(e => e.IdCurso)
                      .ValueGeneratedOnAdd();

                // Campos
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.AnioCalendario)
                      .IsRequired();

                entity.Property(e => e.Cupo)
                      .IsRequired();

                entity.Property(e => e.IDComision)
                      .IsRequired();

                entity.Property(e => e.IDMateria)
                      .IsRequired();

                // Índices útiles
                entity.HasIndex(e => e.IDComision)
                      .HasDatabaseName("IX_Cursos_IDComision");

                entity.HasIndex(e => e.IDMateria)
                      .HasDatabaseName("IX_Cursos_IDMateria");

                // Evitar cursos duplicados para la misma (Comisión, Materia, Año)
                entity.HasIndex(e => new { e.IDComision, e.IDMateria, e.AnioCalendario })
                      .IsUnique()
                      .HasDatabaseName("UX_Cursos_Comision_Materia_Anio");

                // Relaciones (FK) — sin cascada para evitar multiple cascade paths
                entity.HasOne(e => e.Comision)
                      .WithMany(c => c.Cursos) // si no tenés colección: .WithMany()
                      .HasForeignKey(e => e.IDComision)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_Cursos_Comisiones_IDComision");

                entity.HasOne(e => e.Materia)
                      .WithMany(m => m.Cursos) // si no tenés colección: .WithMany()
                      .HasForeignKey(e => e.IDMateria)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_Cursos_Materias_IDMateria");
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

                entity.HasOne(p => p.Plan)
                      .WithMany(e => e.Personas)
                      .HasForeignKey(p => p.IDPlan) // <-- clavec
                      .HasConstraintName("FK_Personas_Planes_IDPLan")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- PLAN ---
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(p => p.IDPlan);
                entity.Property(p => p.DescPlan).IsRequired().HasMaxLength(50);
                entity.Property(p => p.IDEspecialidad).IsRequired();

                entity.HasOne(p => p.Especialidad)
                      .WithMany(e => e.Planes)
                      .HasForeignKey(p => p.IDEspecialidad) // <-- clavec
                      .HasConstraintName("FK_Planes_Especialidades_IDEspecialidad")
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

            // --- COMISION --- 
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

                entity.HasOne(c => c.Plan)
                      .WithMany(c => c.Comisiones)
                      .HasForeignKey(c => c.IDPlan)
                      .HasConstraintName("FK_Comisiones_Planes_IDPLan")
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

                entity.HasOne(ai => ai.Alumno)
                      .WithMany(p => p.AlumnoInscripciones)
                      .HasForeignKey(ai => ai.IDAlumno)
                        .HasConstraintName("FK_AlumnosInscripciones_Personas_IDAlumno")
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ai => ai.Curso)
                      .WithMany(c => c.AlumnoInscripciones)
                      .HasForeignKey(ai => ai.IDCurso)
                      .HasConstraintName("FK_AlumnosInscripciones_Cursos_IDCurso")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            /*entity.HasOne(p => p.Especialidad)
                      .WithMany(e => e.Planes)
                      .HasForeignKey(p => p.IDEspecialidad) // <-- clavec
                      .HasConstraintName("FK_Planes_Especialidades_IDEspecialidad")
                      .OnDelete(DeleteBehavior.Restrict);
            */


        }
    }
}
