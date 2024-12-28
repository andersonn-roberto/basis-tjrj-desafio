namespace LivrosApp.Dominio.Models
{
    public class CanalVenda
    {
        public int CodCv { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<TabelaPreco> TabelaPrecos { get; } = [];
    }
}
