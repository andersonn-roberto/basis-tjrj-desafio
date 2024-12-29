using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Inputs
{
    public class LivroUpdateModel : LivroCreateModel
    {
        public int CodL { get; set; }

        public new Livro ToLivro()
        {
            var livro = new Livro
            {
                CodL = CodL,
                AnoPublicacao = AnoPublicacao,
                Edicao = Edicao,
                Editora = Editora,
                Titulo = Titulo,
                LivrosAutores = [.. LivrosAutores.Select(la => new LivroAutor { Autor_CodAu = la, Livro_CodL = CodL })],
                LivrosAssuntos = [.. LivrosAssuntos.Select(la => new LivroAssunto { Assunto_CodAs = la, Livro_CodL = CodL })],
                TabelaPrecos = [.. TabelaPrecos.Select(tp => tp.ToTabelaPreco(CodL))]
            };

            return livro;
        }
    }
}
