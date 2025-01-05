using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    public class AutorDto
    {
        public int CodAu { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(40)]
        public string Nome { get; set; }
    }
}
