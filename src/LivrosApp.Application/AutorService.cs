using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class AutorService : IAutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAutor(Autor detalhesAutor)
        {
            if (detalhesAutor != null)
            {
                await _unitOfWork.Autores.Add(detalhesAutor);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<(bool, string)> DeleteAutor(int codAu)
        {
            if (codAu > 0)
            {
                var hasLivro = (await _unitOfWork.LivrosAutores.GetAll(la => la.Autor_CodAu == codAu)).Any();
                if (hasLivro)
                    return (false, "Não é possível excluir um autor relacionado à um livro.");

                var autor = await _unitOfWork.Autores.GetById(codAu);
                if (autor != null)
                {
                    _unitOfWork.Autores.Remove(autor);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return (true, "");
                    else
                        return (false, "");
                }
            }
            return (false, "");
        }
        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            return await _unitOfWork.Autores.GetAll();
        }
        public async Task<Autor> GetAutorById(int codAu)
        {
            if (codAu > 0)
            {
                var autor = await _unitOfWork.Autores.GetById(codAu);

                if (autor != null)
                {
                    return autor;
                }
            }
            return null;
        }
        public async Task<bool> UpdateAutor(Autor detalhesAutor)
        {
            if (detalhesAutor != null)
            {
                var autor = await _unitOfWork.Autores.GetById(detalhesAutor.CodAu);
                if (autor != null)
                {
                    autor.Nome = detalhesAutor.Nome;

                    _unitOfWork.Autores.Update(autor);

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
