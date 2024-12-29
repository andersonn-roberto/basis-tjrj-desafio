using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class LivroAssuntoService : ILivroAssuntoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LivroAssuntoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateLivroAssunto(LivroAssunto detalhesLivroAssunto)
        {
            if (detalhesLivroAssunto != null)
            {
                await _unitOfWork.LivrosAssuntos.Add(detalhesLivroAssunto);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteLivroAssunto(int codLa)
        {
            if (codLa > 0)
            {
                var livroAssunto = await _unitOfWork.LivrosAssuntos.GetById(codLa);
                if (livroAssunto != null)
                {
                    _unitOfWork.LivrosAssuntos.Remove(livroAssunto);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<LivroAssunto>> GetAllLivrosAssuntos()
        {
            return await _unitOfWork.LivrosAssuntos.GetAll();
        }
        public async Task<LivroAssunto> GetLivroAssuntoById(int codLa)
        {
            if (codLa > 0)
            {
                var livroAssunto = await _unitOfWork.LivrosAssuntos.GetById(codLa);

                if (livroAssunto != null)
                {
                    return livroAssunto;
                }
            }
            return null;
        }
        public async Task<bool> UpdateLivroAssunto(LivroAssunto detalhesLivroAssunto)
        {
            if (detalhesLivroAssunto != null)
            {
                var livroAssunto = await _unitOfWork.LivrosAssuntos.GetById(detalhesLivroAssunto.CodLa);

                if (livroAssunto != null)
                {
                    livroAssunto.Livro_CodL = detalhesLivroAssunto.Livro_CodL;
                    livroAssunto.Assunto_CodAs = detalhesLivroAssunto.Assunto_CodAs;

                    _unitOfWork.LivrosAssuntos.Update(livroAssunto);

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
