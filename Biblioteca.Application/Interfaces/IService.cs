using Biblioteca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface IService<TDto> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int? id);
        Task<TDto> AddAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task RemoveAsync(int? id);
    }
}
