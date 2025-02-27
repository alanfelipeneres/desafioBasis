﻿using Biblioteca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface IAssuntoService : IService<AssuntoDto>
    {
        Task<IEnumerable<AssuntoDto>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
