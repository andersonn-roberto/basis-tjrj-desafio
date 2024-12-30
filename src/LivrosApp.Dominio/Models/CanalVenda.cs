using System.ComponentModel.DataAnnotations;

namespace LivrosApp.Dominio.Models
{
    public class CanalVenda
    {
        public int CodCv { get; set; }
        [MaxLength(20, ErrorMessage = "O campo Nome pode conter apenas 20 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        public List<TabelaPreco> TabelaPrecos { get; } = [];
    }
}
