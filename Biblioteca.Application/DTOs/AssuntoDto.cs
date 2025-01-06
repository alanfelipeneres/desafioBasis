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

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
