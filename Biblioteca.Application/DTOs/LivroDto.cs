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
        [MaxLength(40, ErrorMessage = "O Título deve ter no máximo 40 caracteres")]
        [MinLength(3, ErrorMessage = "O Título deve ter no mínimo 3 caracteres")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A Editora é obrigatória")]
        [MaxLength(40, ErrorMessage = "A Editora deve ter no máximo 40 caracteres")]
        [MinLength(3, ErrorMessage = "A Editora deve ter no mínimo 3 caracteres")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "A Edição é obrigatória")]
        [Range(1, 100, ErrorMessage = "A Edição deve estar entre 1 e 100")]
        [DisplayName("Edição")]
        public int Edicao { get; set; }

        [Required(ErrorMessage = "O Ano de Publicação é obrigatório")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "O Ano de Publicação deve ser um ano válido no formato 'YYYY'")]
        [Range(1900, 2099, ErrorMessage = "O Ano de Publicação deve estar entre 1900 e 2099")]
        [DisplayName("Ano de Publicação")]
        public string AnoPublicacao { get; set; }

        // IDs dos Autores relacionados ao Livro
        [Required(ErrorMessage = "Ao menos um Autor deve ser informado")]
        [MinLength(1, ErrorMessage = "Deve haver pelo menos um Autor associado ao Livro")]
        public List<int> AutoresIds { get; set; }

        // IDs dos Assuntos relacionados ao Livro
        [Required(ErrorMessage = "Ao menos um Assunto deve ser informado")]
        [MinLength(1, ErrorMessage = "Deve haver pelo menos um Assunto associado ao Livro")]
        public List<int> AssuntosIds { get; set; }
    }
}
