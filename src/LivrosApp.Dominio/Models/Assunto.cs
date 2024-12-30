using System.ComponentModel.DataAnnotations;

namespace LivrosApp.Dominio.Models
{
    public class Assunto
    {
        public int CodAs { get; set; }
        [MaxLength(20, ErrorMessage = "O campo Descricao pode conter apenas 20 caracteres.")]
        public required string Descricao { get; set; }
        public List<LivroAssunto> LivrosAssuntos { get; } = [];
    }
}
