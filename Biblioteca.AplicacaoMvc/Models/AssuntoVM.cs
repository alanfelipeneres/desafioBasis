using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Biblioteca.AplicacaoMvc.Models
{
    public class AssuntoVM
    {
        public int? CodAs { get; set; }
        public string Descricao { get; set; }
    }
}
