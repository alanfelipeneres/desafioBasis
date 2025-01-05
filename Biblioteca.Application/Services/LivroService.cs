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
        public LivroService(IRepository<Livro> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
