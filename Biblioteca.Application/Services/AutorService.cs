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

        public override async Task<AutorDto> AddAsync(AutorDto autorDto)
        {
            ValidarRegras(autorDto);

            var autor = _mapper.Map<Autor>(autorDto);
            return _mapper.Map<AutorDto>(await _repository.CreateAsync(autor));
        }

        public override async Task<AutorDto> UpdateAsync(AutorDto autorDto)
        {
            ValidarRegras(autorDto);

            var autor = _mapper.Map<Autor>(autorDto);
            return _mapper.Map<AutorDto>(await _repository.UpdateAsync(autor));
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

        private static void ValidarRegras(AutorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
            {
                throw new ArgumentException("O Nome é obrigatório.");
            }

            if (dto.Nome.Length < 3)
            {
                throw new ArgumentException("O Nome deve ter no mínimo 3 caracteres.");
            }

            if (dto.Nome.Length > 40)
            {
                throw new ArgumentException("O Nome deve ter no máximo 40 caracteres.");
            }
        }
    }

    
}
