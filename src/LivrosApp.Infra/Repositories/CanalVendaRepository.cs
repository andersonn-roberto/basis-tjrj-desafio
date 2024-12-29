using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class CanalVendaRepository : BaseRepository<CanalVenda>, ICanalVendaRepository
    {
        public CanalVendaRepository(LivrosAppContext context) : base(context) { }
    }
}
