using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    public class LivroDto
    {
        public int CodL { get; set; }

        [Required(ErrorMessage = "O Título é obrigatório")]
        [MaxLength(40)]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A Editora é obrigatória")]
        [MaxLength(40)]
        public string Editora { get; set; }

        [Required(ErrorMessage = "A Edição é obrigatória")]
        [DisplayName("Edição")]
        public int Edicao { get; set; }

        [Required(ErrorMessage = "O Ano de Publicação é obrigatório")]
        [DisplayName("Ano de Publicação")]
        public string AnoPublicacao { get; set; }

        // IDs dos Autores relacionados ao Livro
        public List<int> AutoresIds { get; set; }

        // IDs dos Assuntos relacionados ao Livro
        public List<int> AssuntosIds { get; set; }
    }
}
