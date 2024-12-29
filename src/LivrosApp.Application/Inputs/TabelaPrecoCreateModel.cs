using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Inputs
{
    public class TabelaPrecoCreateModel
    {
        public decimal Valor { get; set; }
        public int CodCv { get; set; }

        public TabelaPreco ToTabelaPreco(Livro livro)
        {
            return new TabelaPreco
            {
                CodCv = CodCv,
                Livro = livro,
                Valor = Valor
            };
        }

        public TabelaPreco ToTabelaPreco(int livroCodL)
        {
            return new TabelaPreco
            {
                CodCv = CodCv,
                CodL = livroCodL,
                Valor = Valor
            };
        }
    }
}
