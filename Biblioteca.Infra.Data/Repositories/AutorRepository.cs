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
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<Autor> GetByIdWithRelationsAsync(int id)
        {
            return await _context.Autores
                .Include(l => l.Livros)
                .FirstOrDefaultAsync(l => l.CodAu == id);
        }
    }
}
