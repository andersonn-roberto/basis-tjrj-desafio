using LivrosApp.Dominio.Models;
using System.ComponentModel.DataAnnotations;

namespace LivrosApp.Application.Inputs
{
    public class LivroCreateModel
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [MaxLength(40, ErrorMessage = "O campo Titulo pode conter apenas 40 caracteres.")]
        public required string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        [MaxLength(40, ErrorMessage = "O campo Editora pode conter apenas 40 caracteres.")]
        public required string Editora { get; set; }
        [Required(ErrorMessage = "O campo Edicao é obrigatório.")]
        public int Edicao { get; set; }
        [Required(ErrorMessage = "O campo Ano Publicacao é obrigatório.")]
        [MaxLength(4, ErrorMessage = "O campo Ano Publicacao pode conter apenas 4 caracteres.")]
        public required string AnoPublicacao { get; set; }
        [Required(ErrorMessage = "O campo Livros Autores é obrigatório.")]
        public List<int> LivrosAutores { get; set; } = [];
        [Required(ErrorMessage = "O campo Livros Assuntos é obrigatório.")]
        public List<int> LivrosAssuntos { get; set; } = [];
        [Required(ErrorMessage = "O campo Canal de Venda é obrigatório.")]
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
