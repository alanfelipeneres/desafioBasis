using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    public class AssuntoDto
    {
        public int? CodAs { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MaxLength(20, ErrorMessage = "A Descrição deve ter no máximo 20 caracteres")]
        [MinLength(3, ErrorMessage = "A Descrição deve ter no mínimo 3 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
