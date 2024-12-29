namespace LivrosApp.Dominio.Models
{
    public class Livro
    {
        public int CodL { get; set; }
        public required string Titulo { get; set; }
        public required string Editora { get; set; }
        public int Edicao { get; set; }
        public required string AnoPublicacao { get; set; }
        public List<LivroAutor> LivrosAutores { get; set; } = [];
        public List<LivroAssunto> LivrosAssuntos { get; set; } = [];
        public List<TabelaPreco> TabelaPrecos { get; set; } = [];
    }
}
