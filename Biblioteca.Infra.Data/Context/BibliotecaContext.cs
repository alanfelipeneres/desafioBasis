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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento muitos-para-muitos entre Livro e Autor
            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    "Livro_Autor", // Nome da tabela associativa
                    j => j.HasOne<Autor>().WithMany().HasForeignKey("AutorCodAu"),
                    j => j.HasOne<Livro>().WithMany().HasForeignKey("LivroCodL"));

            // Relacionamento muitos-para-muitos entre Livro e Assunto
            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Assuntos)
                .WithMany(a => a.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    "Livro_Assunto", // Nome da tabela associativa
                    j => j.HasOne<Assunto>().WithMany().HasForeignKey("AssuntoCodAs"),
                    j => j.HasOne<Livro>().WithMany().HasForeignKey("LivroCodL"));
        }
    }
}
