using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int CodAu { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
