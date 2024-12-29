using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class CanalVendaService : ICanalVendaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CanalVendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateCanalVenda(CanalVenda detalhesCanalVenda)
        {
            if (detalhesCanalVenda != null)
            {
                await _unitOfWork.CanaisVenda.Add(detalhesCanalVenda);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<(bool, string)> DeleteCanalVenda(int codCv)
        {
            if (codCv > 0)
            {
                var hasTabelaPreco = (await _unitOfWork.TabelasPrecos.GetAll(tp => tp.CodCv == codCv)).Any();
                if (hasTabelaPreco)
                    return (false, "Não é possível excluir um canal de venda relacionado à uma tabela de preços.");

                var canalVenda = await _unitOfWork.CanaisVenda.GetById(codCv);
                if (canalVenda != null)
                {
                    _unitOfWork.CanaisVenda.Remove(canalVenda);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return (true, "");
                    else
                        return (false, "");
                }
            }
            return (false, "");
        }
        public async Task<IEnumerable<CanalVenda>> GetAllCanaisVenda()
        {
            return await _unitOfWork.CanaisVenda.GetAll();
        }
        public async Task<CanalVenda> GetCanalVendaById(int codCv)
        {
            if (codCv > 0)
            {
                var canalVenda = await _unitOfWork.CanaisVenda.GetById(codCv);
                if (canalVenda != null)
                {
                    return canalVenda;
                }
            }
            return null;
        }
        public async Task<bool> UpdateCanalVenda(CanalVenda detalhesCanalVenda)
        {
            if (detalhesCanalVenda != null)
            {
                var canalVenda = await _unitOfWork.CanaisVenda.GetById(detalhesCanalVenda.CodCv);
                if (canalVenda != null)
                {
                    canalVenda.Nome = detalhesCanalVenda.Nome;
                    _unitOfWork.CanaisVenda.Update(canalVenda);
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
