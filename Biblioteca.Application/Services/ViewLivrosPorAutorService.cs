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
    public class ViewLivrosPorAutorService : IViewLivrosPorAutorService
    {
        private readonly IViewLivrosPorAutorRepository _repository;
        private readonly IMapper _mapper;

        public ViewLivrosPorAutorService(IViewLivrosPorAutorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViewLivrosPorAutorDto>> GetAllAsync()
        {
            var view = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewLivrosPorAutorDto>>(view);
        }
    }
}
