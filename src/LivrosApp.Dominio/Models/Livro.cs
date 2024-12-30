using System.ComponentModel.DataAnnotations;

namespace LivrosApp.Dominio.Models
{
    public class Livro
    {
        public int CodL { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [MaxLength(40, ErrorMessage = "O campo Titulo pode conter apenas 40 caracteres.")]
        public required string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        [MaxLength(40, ErrorMessage = "O campo Editora pode conter apenas 40 caracteres.")]
        public required string Editora { get; set; }
        [Required(ErrorMessage = "O campo Edicao é obrigatório.")]
        public int Edicao { get; set; }
        [Required(ErrorMessage = "O campo Ano Publicacao é obrigatório.")]
        [MaxLength(4, ErrorMessage = "O campo Ano Publicacao pode conter apenas 4 caracteres.")]
        public required string AnoPublicacao { get; set; }
        public List<LivroAutor> LivrosAutores { get; set; } = [];
        public List<LivroAssunto> LivrosAssuntos { get; set; } = [];
        public List<TabelaPreco> TabelaPrecos { get; set; } = [];
    }
}
