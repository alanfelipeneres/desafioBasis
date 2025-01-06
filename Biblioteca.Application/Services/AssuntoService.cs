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
    public class AssuntoService : ServiceBase<AssuntoDto, Assunto>, IAssuntoService
    {
        private readonly IAssuntoRepository _repository;
        private readonly IMapper _mapper;

        public AssuntoService(IAssuntoRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<AssuntoDto> AddAsync(AssuntoDto assuntoDto)
        {
            ValidarRegras(assuntoDto);

            var assunto = _mapper.Map<Assunto>(assuntoDto);
            return _mapper.Map<AssuntoDto>(await _repository.CreateAsync(assunto));
        }

        public override async Task<AssuntoDto> UpdateAsync(AssuntoDto assuntoDto)
        {
            ValidarRegras(assuntoDto);

            var assunto = _mapper.Map<Assunto>(assuntoDto);
            return _mapper.Map<AssuntoDto>(await _repository.UpdateAsync(assunto));
        }

        private static void ValidarRegras(AssuntoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Descricao))
            {
                throw new ArgumentException("A Descrição é obrigatória.");
            }

            if (dto.Descricao.Length < 3)
            {
                throw new ArgumentException("A Descrição deve ter no mínimo 3 caracteres.");
            }

            if (dto.Descricao.Length > 20)
            {
                throw new ArgumentException("A Descrição deve ter no máximo 20 caracteres.");
            }
        }

        public async Task<IEnumerable<AssuntoDto>> GetByIdsAsync(IEnumerable<int> ids)
        {
            var assuntos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssuntoDto>>(assuntos.Where(a => ids.Contains(a.CodAs)));
        }

        public override async Task RemoveAsync(int? id)
        {
            var entity = await _repository.GetByIdWithRelationsAsync(id.Value);

            if (entity.Livros.Any()) 
            {
                throw new InvalidOperationException("Assunto vinculado a um livro não pode ser excluído.");
            }

            if (entity != null)
            {
                await _repository.RemoveAsync(entity);
            }
        }
    }
}
