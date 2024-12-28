namespace LivrosApp.Dominio.Models
{
    public class Autor
    {
        public int CodAu { get; set; }
        public required string Nome { get; set; }
        public List<LivroAutor> LivrosAutores { get; } = [];
    }
}
