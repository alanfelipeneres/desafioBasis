using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Biblioteca.AplicacaoMvc.Models
{
    public class LivroVM
    {
        public int CodL { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public List<int> AutoresIds { get; set; }
        public List<int> AssuntosIds { get; set; }
    }
}
