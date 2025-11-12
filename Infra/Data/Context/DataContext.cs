using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<ProgressoCurso> ProgressoCursos { get; set; }
        public DbSet<Material> Materiais { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ------------------ Usuario ------------------
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Cargo).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SenhaHash).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
            });

            // -------------- Avaliacao ---------------
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.ToTable("Avaliacoes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUsuario).IsRequired();
                entity.Property(e => e.IdCurso).IsRequired();
                entity.Property(e => e.Nota);
                entity.Property(e => e.Comentario).HasMaxLength(500);
            });

            // -------------- Pergunta ---------
            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.ToTable("Perguntas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Texto).HasMaxLength(500).IsRequired();
                entity.Property(e => e.Opcoes)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null),
                    v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions)null)
                )
                .HasColumnType("TEXT");

            });

            // ----------- Certificado --------------
            modelBuilder.Entity<Certificado>(entity =>
            {
                entity.ToTable("Certificados");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUsuario).IsRequired();
                entity.Property(e => e.IdCurso).IsRequired();
                entity.Property(e => e.DataEmissao).IsRequired();
                entity.Property(e => e.CodigoValidacao)
                      .HasMaxLength(20)
                      .IsRequired();
            });

            // ------------- Curso ----------------
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("Cursos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Descricao).HasMaxLength(500).IsRequired();
                entity.Property(e => e.NotaMinima).IsRequired();
            });

            // ----------- Presenca ----------------
            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.ToTable("Presencas");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdUsuario).IsRequired();
                entity.Property(e => e.IdCurso).IsRequired();
                entity.Property(e => e.Data).IsRequired();
                entity.Property(e => e.Presente).IsRequired();
            });

            //--------------Progresso--------
            modelBuilder.Entity<ProgressoCurso>(entity =>
            {
                entity.ToTable("ProgressoCursos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUsuario).IsRequired();
                entity.Property(e => e.IdModulo).IsRequired();
                entity.Property(e => e.DataConclusao).IsRequired();
            });

            //----------------Material----------
            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Materiais");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdCurso).IsRequired();
                entity.Property(e => e.NomeArquivo).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Caminho).HasMaxLength(300).IsRequired();
                entity.Property(e => e.Tipo).HasMaxLength(50).IsRequired();
                entity.Property(e => e.DataUpload).IsRequired();
            });

        }
    }
}
