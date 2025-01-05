using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Repositories
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<Livro> GetByIdWithRelationsAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .FirstOrDefaultAsync(l => l.CodL == id);
        }
    }
}
