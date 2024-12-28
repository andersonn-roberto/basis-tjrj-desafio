namespace LivrosApp.Dominio.Models
{
    public class LivroAssunto
    {
        public int CodLa { get; set; }
        public int Livro_CodL { get; set; }
        public required Livro Livro { get; set; }
        public int Assunto_CodAs { get; set; }
        public required Assunto Assunto { get; set; }
    }
}
