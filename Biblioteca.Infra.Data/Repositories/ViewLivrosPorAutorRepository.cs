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
    public class ViewLivrosPorAutorRepository : IViewLivrosPorAutorRepository
    {
        private readonly BibliotecaContext _context;

        public ViewLivrosPorAutorRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ViewLivrosPorAutor>> GetAllAsync()
        {
            return await _context.LivroPorAutor.ToListAsync();
        }
    }
}
