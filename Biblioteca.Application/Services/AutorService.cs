using AutoMapper;
using Biblioteca.Application.DTOs;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class AutorService : ServiceBase<AutorDto, Autor>, IAutorService
    {
        private readonly IAutorRepository _repository;
        private readonly IMapper _mapper;

        public AutorService(IAutorRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AutorDto>> GetByIdsAsync(IEnumerable<int> ids)
        {
            var autores = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AutorDto>>(autores.Where(a => ids.Contains(a.CodAu)));
        }

        public override async Task RemoveAsync(int? id)
        {
            var entity = await _repository.GetByIdWithRelationsAsync(id.Value);

            if (entity.Livros.Any())
            {
                throw new InvalidOperationException("Autor vinculado a um livro não pode ser excluído.");
            }

            if (entity != null)
            {
                await _repository.RemoveAsync(entity);
            }
        }
    }

    
}
