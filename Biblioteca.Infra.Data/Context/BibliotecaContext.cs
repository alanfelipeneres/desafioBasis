using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<ViewLivrosPorAutor> LivroPorAutor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relação muitos-para-muitos entre Livro e Autor
            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    "Livro_Autor",
                    j => j.HasOne<Autor>()
                          .WithMany()
                          .HasForeignKey("Autor_CodAu")
                          .HasConstraintName("FK_Livro_Autor_Autor"),
                    j => j.HasOne<Livro>()
                          .WithMany()
                          .HasForeignKey("Livro_CodL")
                          .HasConstraintName("FK_Livro_Autor_Livro"));

            // Relação muitos-para-muitos entre Livro e Assunto
            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Assuntos)
                .WithMany(a => a.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    "Livro_Assunto",
                    j => j.HasOne<Assunto>()
                          .WithMany()
                          .HasForeignKey("Assunto_CodAs")
                          .HasConstraintName("FK_Livro_Assunto_Assunto"),
                    j => j.HasOne<Livro>()
                          .WithMany()
                          .HasForeignKey("Livro_CodL")
                          .HasConstraintName("FK_Livro_Assunto_Livro"));

            // Configura o modelo para a view
            modelBuilder.Entity<ViewLivrosPorAutor>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_LivrosPorAutor");
            });
        }
    }
}
