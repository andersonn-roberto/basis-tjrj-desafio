namespace LivrosApp.Dominio.Models
{
    public class Assunto
    {
        public int CodAs { get; set; }
        public required string Descricao { get; set; }
        public List<LivroAssunto> LivrosAssuntos { get; } = [];
    }
}
