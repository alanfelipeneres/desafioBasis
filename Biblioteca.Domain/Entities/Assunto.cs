using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    [Table("Assunto")]
    public class Assunto
    {
        [Key]
        public int CodAs { get; set; }
        public string Descricao { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
