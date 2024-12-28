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

        public async Task<bool> CreateLivro(Livro detalhesLivro)
        {
            if (detalhesLivro != null)
            {
                await _unitOfWork.Livros.Add(detalhesLivro);

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
            return await _unitOfWork.Livros.GetAll();
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

        public async Task<bool> UpdateLivro(Livro detalhesLivro)
        {
            if (detalhesLivro != null)
            {
                var livro = await _unitOfWork.Livros.GetById(detalhesLivro.CodL);
                if (livro != null)
                {
                    livro.Titulo = detalhesLivro.Titulo;
                    livro.Editora = detalhesLivro.Editora;
                    livro.Edicao = detalhesLivro.Edicao;
                    livro.AnoPublicacao = detalhesLivro.AnoPublicacao;

                    _unitOfWork.Livros.Update(livro);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
