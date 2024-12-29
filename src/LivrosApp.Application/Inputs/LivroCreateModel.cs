using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Inputs
{
    public class LivroCreateModel
    {
        public required string Titulo { get; set; }
        public required string Editora { get; set; }
        public int Edicao { get; set; }
        public required string AnoPublicacao { get; set; }
        public List<int> LivrosAutores { get; set; } = [];
        public List<int> LivrosAssuntos { get; set; } = [];
        public List<TabelaPrecoCreateModel> TabelaPrecos { get; set; } = [];

        public Livro ToLivro()
        {
            var livro = new Livro
            {
                AnoPublicacao = AnoPublicacao,
                Edicao = Edicao,
                Editora = Editora,
                Titulo = Titulo
            };
            livro.LivrosAutores = [.. LivrosAutores.Select(la => new LivroAutor { Autor_CodAu = la, Livro = livro })];
            livro.LivrosAssuntos = [.. LivrosAssuntos.Select(la => new LivroAssunto { Assunto_CodAs = la, Livro = livro })];
            livro.TabelaPrecos = [.. TabelaPrecos.Select(tp => tp.ToTabelaPreco(livro))];

            return livro;
        }
    }
}
