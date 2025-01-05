using AutoMapper;
using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() {
            CreateMap<Assunto, AssuntoDto>().ReverseMap();
            CreateMap<Autor, AutorDto>().ReverseMap();
            CreateMap<Livro, LivroDto>().ReverseMap();
        }
    }
}
