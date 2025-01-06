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
    public class AssuntoRepository : RepositoryBase<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<Assunto> GetByIdWithRelationsAsync(int id)
        {
            return await _context.Assuntos
                .Include(l => l.Livros)
                .FirstOrDefaultAsync(l => l.CodAs == id);
        }
    }
}
