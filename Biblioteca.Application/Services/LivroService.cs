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
    public class LivroService : ServiceBase<LivroDto, Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMapper _mapper;
        private readonly IAutorService _autorService;
        private readonly IAssuntoService _assuntoService;

        public LivroService(ILivroRepository livroRepository,
            IMapper mapper,
            IAutorRepository repositoryAutor,
            IAssuntoRepository repositoryAssunto) : base(livroRepository, mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
            _autorRepository = repositoryAutor;
            _assuntoRepository = repositoryAssunto;
        }

        public override async Task<IEnumerable<LivroDto>> GetAllAsync()
        {
            var entities = await _livroRepository.GetAllAsync();


            return _mapper.Map<IEnumerable<LivroDto>>(entities);
        }

        public override async Task<LivroDto> AddAsync(LivroDto livroDto)
        {
            // Mapeia o DTO para a entidade Livro
            var livro = _mapper.Map<Livro>(livroDto);

            // Relaciona os Autores
            if (livroDto.AutoresIds != null && livroDto.AutoresIds.Any())
            {
                if (livro.Autores == null) livro.Autores = new List<Autor>();

                foreach (var autorId in livroDto.AutoresIds)
                {
                    // Busque a entidade Autor do banco de dados
                    var autor = await _autorRepository.GetByIdAsync(autorId);

                    if (autor != null)
                    {
                        // Adicione a entidade existente à coleção
                        livro.Autores.Add(autor);
                    }
                }
            }

            // Relaciona os Assuntos
            if (livroDto.AssuntosIds != null && livroDto.AssuntosIds.Any())
            {
                if (livro.Assuntos == null) livro.Assuntos = new List<Assunto>();

                foreach (var assuntoId in livroDto.AssuntosIds)
                {
                    // Busque a entidade Assunto do banco de dados
                    var assunto = await _assuntoRepository.GetByIdAsync(assuntoId);

                    if (assunto != null)
                    {
                        // Adicione a entidade existente à coleção
                        livro.Assuntos.Add(assunto);
                    }
                }
            }

            // Salva o livro no banco de dados
            await _livroRepository.CreateAsync(livro);

            // Retorna o livro salvo
            return _mapper.Map<LivroDto>(livro);
        }
    }
}
