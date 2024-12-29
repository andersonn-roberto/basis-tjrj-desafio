using LivrosApp.Application.Inputs;
using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class LivroService : ILivroService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LivroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateLivro(LivroCreateModel detalhesLivro)
        {
            if (detalhesLivro != null)
            {
                var livro = detalhesLivro.ToLivro();

                await _unitOfWork.Livros.Add(livro);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteLivro(int codL)
        {
            if (codL > 0)
            {
                var livro = await _unitOfWork.Livros.GetById(codL);
                if (livro != null)
                {
                    _unitOfWork.Livros.Remove(livro);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            return await _unitOfWork.Livros.GetAll(includeProperties: "LivrosAutores,LivrosAutores.Autor,LivrosAssuntos.Assunto,TabelaPrecos");
        }

        public async Task<Livro> GetLivroById(int codL)
        {
            if (codL > 0)
            {
                var livro = await _unitOfWork.Livros.GetById(codL);
                if (livro != null)
                {
                    return livro;
                }
            }
            return null;
        }

        public async Task<bool> UpdateLivro(LivroUpdateModel detalhesLivro)
        {
            if (detalhesLivro != null)
            {
                var livro = await _unitOfWork.Livros.GetAll(l => l.CodL == detalhesLivro.CodL, includeProperties: "LivrosAutores,LivrosAssuntos,TabelaPrecos");
                var livroParaAtualizar = livro.First();

                if (livroParaAtualizar != null)
                {
                    livroParaAtualizar.Titulo = detalhesLivro.Titulo;
                    livroParaAtualizar.Editora = detalhesLivro.Editora;
                    livroParaAtualizar.Edicao = detalhesLivro.Edicao;
                    livroParaAtualizar.AnoPublicacao = detalhesLivro.AnoPublicacao;

                    await UpdateLivroAssuntos(detalhesLivro, livroParaAtualizar);
                    await UpdateLivroAutores(detalhesLivro, livroParaAtualizar);
                    await UpdateTabelaPrecos(detalhesLivro, livroParaAtualizar);

                    _unitOfWork.Livros.Update(livroParaAtualizar);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        private async Task UpdateLivroAssuntos(LivroUpdateModel detalhesLivro, Livro livroParaAtualizar)
        {
            var assuntosSelecionados = new HashSet<int>(detalhesLivro.LivrosAssuntos);
            var livroAssuntos = new HashSet<int>(livroParaAtualizar.LivrosAssuntos.Select(la => la.Assunto_CodAs));

            var allAssuntos = (await _unitOfWork.Assuntos.GetAll()).Select(assunto => assunto.CodAs);

            foreach (var assuntoCodAs in allAssuntos)
            {
                if (assuntosSelecionados.Contains(assuntoCodAs))
                {
                    if (!livroAssuntos.Contains(assuntoCodAs))
                    {
                        livroParaAtualizar.LivrosAssuntos.Add(new LivroAssunto { Assunto_CodAs = assuntoCodAs, Livro_CodL = livroParaAtualizar.CodL });
                    }
                }
                else
                {
                    if (livroAssuntos.Contains(assuntoCodAs))
                    {
                        var livroAssuntoSelecionado = livroParaAtualizar.LivrosAssuntos.First(la => la.Assunto_CodAs == assuntoCodAs);
                        livroParaAtualizar.LivrosAssuntos.Remove(livroAssuntoSelecionado);
                    }
                }
            }
        }
        private async Task UpdateLivroAutores(LivroUpdateModel detalhesLivro, Livro livroParaAtualizar)
        {
            var autoresSelecionados = new HashSet<int>(detalhesLivro.LivrosAutores);
            var livroAutores = new HashSet<int>(livroParaAtualizar.LivrosAutores.Select(la => la.Autor_CodAu));

            var allAutores = (await _unitOfWork.Autores.GetAll()).Select(autor => autor.CodAu);

            foreach (var autorCodAu in allAutores)
            {
                if (autoresSelecionados.Contains(autorCodAu))
                {
                    if (!livroAutores.Contains(autorCodAu))
                    {
                        livroParaAtualizar.LivrosAutores.Add(new LivroAutor { Autor_CodAu = autorCodAu, Livro_CodL = livroParaAtualizar.CodL });
                    }
                }
                else
                {
                    if (livroAutores.Contains(autorCodAu))
                    {
                        var livroAutorSelecionado = livroParaAtualizar.LivrosAutores.First(la => la.Autor_CodAu == autorCodAu);
                        livroParaAtualizar.LivrosAutores.Remove(livroAutorSelecionado);
                    }
                }
            }
        }
        private async Task UpdateTabelaPrecos(LivroUpdateModel detalhesLivro, Livro livroParaAtualizar)
        {
            var canaisVendaSelecionados = new HashSet<int>(detalhesLivro.TabelaPrecos.Select(tp => tp.CodCv));
            var livroTabelasPrecos = new HashSet<int>(livroParaAtualizar.TabelaPrecos.Select(tp => tp.CodCv));

            var allCanaisVenda = (await _unitOfWork.CanaisVenda.GetAll()).Select(canalVenda => canalVenda.CodCv);

            foreach (var canalVendaCodCv in allCanaisVenda)
            {
                if (canaisVendaSelecionados.Contains(canalVendaCodCv))
                {
                    if (!livroTabelasPrecos.Contains(canalVendaCodCv))
                    {
                        livroParaAtualizar.TabelaPrecos.Add(new TabelaPreco { CodL = livroParaAtualizar.CodL, CodCv = canalVendaCodCv, Valor = detalhesLivro.TabelaPrecos.First(tp => tp.CodCv == canalVendaCodCv).Valor });
                    }
                }
                else
                {
                    if (livroTabelasPrecos.Contains(canalVendaCodCv))
                    {
                        var livroCanalVendaSelecionado = livroParaAtualizar.TabelaPrecos.First(tp => tp.CodCv == canalVendaCodCv);
                        livroParaAtualizar.TabelaPrecos.Remove(livroCanalVendaSelecionado);
                    }
                }
            }
        }
    }
}
