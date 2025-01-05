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
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly BibliotecaContext _context;

        public RepositoryBase(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entidade)
        {
            // Para garantir que o EF Core gerencie corretamente as entidades relacionadas
            _context.Entry(entidade).State = EntityState.Added;

            // Para entidades relacionadas (ex.: Autores ou Assuntos)
            var navigationProperties = _context.Entry(entidade).Navigations;

            foreach (var navigation in navigationProperties)
            {
                if (navigation.CurrentValue != null)
                {
                    foreach (var relatedEntity in (IEnumerable<object>)navigation.CurrentValue)
                    {
                        _context.Attach(relatedEntity);
                    }
                }
            }

            // Salva no banco de dados
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> RemoveAsync(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<T> UpdateAsync(T entidade)
        {
            _context.Set<T>().Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }
    }
}
