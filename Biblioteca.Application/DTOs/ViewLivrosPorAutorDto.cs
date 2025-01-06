using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    public class ViewLivrosPorAutorDto
    {
        public string Autor { get; set; }
        public string Livro { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public string Assuntos { get; set; }
    }
}
