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
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Materia> Materias { get; set; }      
        public DbSet<ComisionMateria> ComisionesMaterias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<DocenteCurso> DocentesCursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<ModuloUsuario> ModulosUsuarios { get; set; }



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
                e.ToTable("Especialidades");
                e.HasKey(x => x.IDEspecialidad);
                e.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            });

            // --- PLAN ---
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Planes");
                entity.HasKey(p => p.IDPlan);
                entity.Property(p => p.DescPlan).IsRequired().HasMaxLength(50);
                entity.Property(p => p.IDEspecialidad).IsRequired();

                entity.HasOne(p => p.Especialidad)
                      .WithMany(e => e.Planes)
                      .HasForeignKey(p => p.IDEspecialidad) // <-- clavec
                      .HasConstraintName("FK_Planes_Especialidades_IDEspecialidad")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- COMISION --- 
            modelBuilder.Entity<Comision>(entity =>
            {
                entity.ToTable("Comisiones");
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
                      .WithMany(p => p.Comisiones)
                      .HasForeignKey(c => c.IDPlan) // <-- clavec
                      .HasConstraintName("FK_Comisiones_Planes_IDPLan")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- MATERIA ---
            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("Materias");
                entity.HasKey(m => m.IDMateria);

                entity.Property(m => m.IDMateria)
                      .ValueGeneratedOnAdd();

                entity.Property(m => m.Descripcion)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // --- COMISION MATERIA ---
            modelBuilder.Entity<ComisionMateria>(entity =>
            {
                entity.ToTable("ComisionesMaterias");
                entity.HasKey(cm => cm.IDComisionMateria);
                entity.Property(cm => cm.IDComisionMateria)
                      .ValueGeneratedOnAdd();
                entity.Property(cm => cm.HsSemanales).IsRequired();
                entity.Property(cm => cm.HsTotales).IsRequired();
                entity.Property(cm => cm.IDComision).IsRequired();
                entity.Property(cm => cm.IDMateria).IsRequired();
                entity.HasOne(cm => cm.Comision)
                      .WithMany(c => c.ComisionesMaterias)
                      .HasForeignKey(cm => cm.IDComision)
                      .HasConstraintName("FK_ComisionesMaterias_Comisiones_IDComision")
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(cm => cm.Materia)
                        .WithMany(m => m.ComisionesMaterias)
                        .HasForeignKey(cm => cm.IDMateria)
                        .HasConstraintName("FK_ComisionesMaterias_Materias_IDMateria")
                        .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(cm => new { cm.IDComision, cm.IDMateria })
                      .IsUnique()
                      .HasDatabaseName("UX_Comision_Materia");

            });

            // --- CURSOS ---
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("Cursos");

                // PK
                entity.HasKey(e => e.IdCurso)
                      .HasName("PK_Cursos");

                entity.Property(e => e.IdCurso)
                      .ValueGeneratedOnAdd();

                // Campos
                entity.Property(c => c.Descripcion)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(c => c.AnioCalendario)
                      .IsRequired();

                entity.Property(c => c.Cupo)
                      .IsRequired();

                entity.Property(c => c.IDComisionMateria)
                      .IsRequired();

                entity.HasOne(c => c.ComisionMateria)
                      .WithMany(cm => cm.Cursos)
                      .HasForeignKey(c => c.IDComisionMateria)
                      .HasConstraintName("FK_Cursos_ComisionesMaterias_IDComisionMateria")
                      .OnDelete(DeleteBehavior.Restrict);

                // Evitar cursos duplicados para la misma (Comisión, Materia, Año)
                entity.HasIndex(c => new { c.IDComisionMateria, c.AnioCalendario })
                      .IsUnique()
                      .HasDatabaseName("UX_Cursos_ComisionMateria_Anio");

            });

            // --- PERSONA ---
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Personas");
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

                entity.Property(p => p.TipoDoc)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.NroDoc)
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

            });

            // --- INSCRIPCIONES ---
            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.ToTable("Inscripciones");

                entity.HasKey(i => i.IDInscripcion);

                entity.Property(i => i.IDInscripcion)
                      .ValueGeneratedOnAdd();

                entity.Property(i => i.IDAlumno).IsRequired();
                entity.Property(i => i.IDCurso).IsRequired();
                entity.Property(i => i.Condicion);
                entity.Property(i => i.NotaFinal);
                entity.HasOne(i => i.Alumno)
                      .WithMany(p => p.Inscripciones)
                      .HasForeignKey(i => i.IDAlumno)
                      .HasConstraintName("FK_Inscripciones_Personas_IDAlumno")
                      .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(i => i.Curso)
                      .WithMany(c => c.Inscripciones)
                      .HasForeignKey(i => i.IDCurso)
                      .HasConstraintName("FK_Inscripciones_Cursos_IDCurso")
                      .OnDelete(DeleteBehavior.Restrict);
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
                /*
                entity.HasOne(dc => dc.Curso)
                      .WithMany(c => c.DocenteCursos)
                      .HasForeignKey(dc => dc.IDCurso)
                      .OnDelete(DeleteBehavior.Restrict);
                */
<<<<<<< HEAD
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
=======
                entity.HasIndex(dc => new { dc.IDCurso, dc.IDDocente })
                      .IsUnique();
>>>>>>> d73ef1e8666db7135d6da3293ef6e1b3685b2160
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

        }
    }
}
