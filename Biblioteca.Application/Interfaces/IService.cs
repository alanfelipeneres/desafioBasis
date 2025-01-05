using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface IService<TDto> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int? id);
        Task<TDto> Add(TDto dto);
        Task Update(TDto dto);
        Task Remove(int? id);
    }
}
