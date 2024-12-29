using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssuntoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAssunto(Assunto detalhesAssunto)
        {
            if (detalhesAssunto != null)
            {
                await _unitOfWork.Assuntos.Add(detalhesAssunto);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<(bool, string)> DeleteAssunto(int codAs)
        {
            if (codAs > 0)
            {
                var hasLivro = (await _unitOfWork.LivrosAssuntos.GetAll(la => la.Assunto_CodAs == codAs)).Any();
                if (hasLivro)
                    return (false, "Não é possível excluir um assunto relacionado à um livro.");

                var assunto = await _unitOfWork.Assuntos.GetById(codAs);
                if (assunto != null)
                {
                    _unitOfWork.Assuntos.Remove(assunto);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return (true, "");
                    else
                        return (false, "");
                }
            }
            return (false, "");
        }
        public async Task<IEnumerable<Assunto>> GetAllAssuntos()
        {
            return await _unitOfWork.Assuntos.GetAll();
        }
        public async Task<Assunto> GetAssuntoById(int codAs)
        {
            if (codAs > 0)
            {
                var assunto = await _unitOfWork.Assuntos.GetById(codAs);
                if (assunto != null)
                {
                    return assunto;
                }
            }
            return null;
        }
        public async Task<bool> UpdateAssunto(Assunto detalhesAssunto)
        {
            if (detalhesAssunto != null)
            {
                var assunto = await _unitOfWork.Assuntos.GetById(detalhesAssunto.CodAs);
                if (assunto != null)
                {
                    assunto.Descricao = detalhesAssunto.Descricao;
                    _unitOfWork.Assuntos.Update(assunto);
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
