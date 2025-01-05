using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface ILivroService : IService<LivroDto>
    {
    }
}
