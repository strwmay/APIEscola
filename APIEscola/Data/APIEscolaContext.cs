// Codigo do Arquivo 
using APIEscola.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Data
{
    public class APIEscolaContext : IdentityDbContext // Herança do IdentityDbContext para autenticação
    {
        // Construtor que recebe as opções de configuração do DbContext
        public APIEscolaContext(DbContextOptions<APIEscolaContext> options) : base(options)
        { }

        // Propriedade DbSet para a tabela
        public DbSet<Aluno> Alunos { get; set; } // Representa a tabela de alunos
        public DbSet<Curso> Cursos { get; set; } // Representa a tabela de cursos
        public DbSet<Turma> Turmas { get; set; } // Representa a tabela de turmas
        public DbSet<Matricula> Matriculas { get; set; } // Representa a tabela de matrículas

        // Sobrecarga do método OnConfiguring para configurar o modelo a partir da IdentityDbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama o método OnModelCreating da classe base para a criação das tabelas padrão
            base.OnModelCreating(modelBuilder);

            // Configurar a criação de tabelas adicionais
            modelBuilder.Entity<Aluno>().ToTable("Alunos"); // Define o nome da tabela para a entidade Aluno
            modelBuilder.Entity<Curso>().ToTable("Cursos"); // Define o nome da tabela para a entidade Curso
            modelBuilder.Entity<Turma>().ToTable("Turmas"); // Define o nome da tabela para a entidade Turma
            modelBuilder.Entity<Matricula>().ToTable("Matriculas"); // Define o nome da tabela para a entidade Matricula
        }
    }
}