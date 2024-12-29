namespace LivrosApp.Dominio.Models
{
    public class TabelaPreco
    {
        public int CodTp { get; set; }
        public int CodL { get; set; }
        public Livro? Livro { get; set; }
        public decimal Valor { get; set; }
        public int CodCv { get; set; }
        public CanalVenda? CanalVenda { get; set; }
    }
}
