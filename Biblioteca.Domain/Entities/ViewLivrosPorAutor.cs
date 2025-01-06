using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class ViewLivrosPorAutor
    {
        public string Autor { get; set; }
        public string Livro { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public string Assuntos { get; set; }
    }
}
