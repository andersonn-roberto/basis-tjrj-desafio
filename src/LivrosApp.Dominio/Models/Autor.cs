using System.ComponentModel.DataAnnotations;

namespace LivrosApp.Dominio.Models
{
    public class Autor
    {
        public int CodAu { get; set; }
        [MaxLength(40, ErrorMessage = "O campo Nome pode conter apenas 40 caracteres.")]
        public required string Nome { get; set; }
        public List<LivroAutor> LivrosAutores { get; } = [];
    }
}
