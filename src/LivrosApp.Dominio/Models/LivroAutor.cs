namespace LivrosApp.Dominio.Models
{
    public class LivroAutor
    {
        public int CodLa { get; set; }
        public int Livro_CodL { get; set; }
        public Livro? Livro { get; set; }
        public int Autor_CodAu { get; set; }
        public Autor? Autor { get; set; }
    }
}
