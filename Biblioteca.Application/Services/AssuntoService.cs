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
        public AssuntoService(IRepository<Assunto> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
