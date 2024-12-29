using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class LivroAutorService : ILivroAutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LivroAutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateLivroAutor(LivroAutor detalhesLivroAutor)
        {
            if (detalhesLivroAutor != null)
            {
                await _unitOfWork.LivrosAutores.Add(detalhesLivroAutor);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteLivroAutor(int codLa)
        {
            if (codLa > 0)
            {
                var livroAutor = await _unitOfWork.LivrosAutores.GetById(codLa);
                if (livroAutor != null)
                {
                    _unitOfWork.LivrosAutores.Remove(livroAutor);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<LivroAutor>> GetAllLivrosAutores()
        {
            return await _unitOfWork.LivrosAutores.GetAll();
        }
        public async Task<LivroAutor> GetLivroAutorById(int codLa)
        {
            if (codLa > 0)
            {
                var livroAutor = await _unitOfWork.LivrosAutores.GetById(codLa);

                if (livroAutor != null)
                {
                    return livroAutor;
                }
            }
            return null;
        }
        public async Task<bool> UpdateLivroAutor(LivroAutor detalhesLivroAutor)
        {
            if (detalhesLivroAutor != null)
            {
                var livroAutor = await _unitOfWork.LivrosAutores.GetById(detalhesLivroAutor.CodLa);
                if (livroAutor != null)
                {
                    livroAutor.Livro_CodL = detalhesLivroAutor.Livro_CodL;
                    livroAutor.Autor_CodAu = detalhesLivroAutor.Autor_CodAu;

                    _unitOfWork.LivrosAutores.Update(livroAutor);

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
