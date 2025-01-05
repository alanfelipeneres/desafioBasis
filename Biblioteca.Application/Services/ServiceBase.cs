using AutoMapper;
using Biblioteca.Application.DTOs;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public abstract class ServiceBase<TDto, TEntity> : IService<TDto>
         where TDto : class
         where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        protected ServiceBase(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return _mapper.Map<TDto>(await _repository.CreateAsync(entity));
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto> GetByIdAsync(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task RemoveAsync(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.RemoveAsync(entity);
            }
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return _mapper.Map<TDto>(await _repository.UpdateAsync(entity));
        }
    }
}
