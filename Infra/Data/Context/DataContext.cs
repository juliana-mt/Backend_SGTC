using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Assessment> Avaliacoes { get; set; }
        public DbSet<Question> Perguntas { get; set; }
        public DbSet<Certificate> Certificados { get; set; }
        public DbSet<Course> Cursos { get; set; }
        public DbSet<Presence> Presencas { get; set; }
        public DbSet<Module> Modulos { get; set; }
        public DbSet<CourseProgress> ProgressoCursos { get; set; }
        public DbSet<Material> Materiais { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ------------------ Usuario ------------------
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Position).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PasswordHash).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Active).IsRequired();
            });

            // -------------- Avaliacao ---------------
            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.ToTable("Avaliacoes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUser).IsRequired();
                entity.Property(e => e.IdCourse).IsRequired();
                entity.Property(e => e.Note);
                entity.Property(e => e.Comment).HasMaxLength(500);
            });

            // -------------- Pergunta ---------
            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Perguntas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).HasMaxLength(500).IsRequired();

                entity.Property(e => e.Options)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
                        v => string.IsNullOrEmpty(v)
                            ? new List<string>()
                            : System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions?)null)
                              ?? new List<string>()
                    )
                    .HasColumnType("TEXT");
            });

            // ----------- Certificado --------------
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificados");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUser).IsRequired();
                entity.Property(e => e.IdCourse).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.ValidationCode)
                      .HasMaxLength(20)
                      .IsRequired();
            });

            // ------------- Curso ----------------
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Cursos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500).IsRequired();
                entity.Property(e => e.MinimumNote).IsRequired();
            });

            // ----------- Presenca ----------------
            modelBuilder.Entity<Presence>(entity =>
            {
                entity.ToTable("Presencas");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdUser).IsRequired();
                entity.Property(e => e.IdCourse).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Present).IsRequired();
            });

            //--------------Progresso--------
            modelBuilder.Entity<CourseProgress>(entity =>
            {
                entity.ToTable("ProgressoCursos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUser).IsRequired();
                entity.Property(e => e.IdCourse).IsRequired();
                entity.Property(e => e.IdModule).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });

            //----------------Material----------
            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Materiais");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdCourse).IsRequired();
                entity.Property(e => e.FileName).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Path).HasMaxLength(300).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(50).IsRequired();
                entity.Property(e => e.DateUpload).IsRequired();
            });

        }
    }
}
