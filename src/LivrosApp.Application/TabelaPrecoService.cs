using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application
{
    public class TabelaPrecoService : ITabelaPrecoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TabelaPrecoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateTabelaPreco(TabelaPreco detalhesTabelaPreco)
        {
            if (detalhesTabelaPreco != null)
            {
                await _unitOfWork.TabelasPrecos.Add(detalhesTabelaPreco);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteTabelaPreco(int codTp)
        {
            if (codTp > 0)
            {
                var tabelaPreco = await _unitOfWork.TabelasPrecos.GetById(codTp);

                if (tabelaPreco != null)
                {
                    _unitOfWork.TabelasPrecos.Remove(tabelaPreco);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<TabelaPreco>> GetAllTabelasPreco()
        {
            return await _unitOfWork.TabelasPrecos.GetAll();
        }
        public async Task<TabelaPreco> GetTabelaPrecoById(int codTp)
        {
            if (codTp > 0)
            {
                var tabelaPreco = await _unitOfWork.TabelasPrecos.GetById(codTp);

                if (tabelaPreco != null)
                {
                    return tabelaPreco;
                }
            }
            return null;
        }
        public async Task<bool> UpdateTabelaPreco(TabelaPreco detalhesTabelaPreco)
        {
            if (detalhesTabelaPreco != null)
            {
                var tabelaPreco = await _unitOfWork.TabelasPrecos.GetById(detalhesTabelaPreco.CodTp);

                if (tabelaPreco != null)
                {
                    tabelaPreco.Valor = detalhesTabelaPreco.Valor;

                    _unitOfWork.TabelasPrecos.Update(tabelaPreco);

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
