using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class TabelaPrecoRepository : BaseRepository<TabelaPreco>, ITabelaPrecoRepository
    {
        public TabelaPrecoRepository(LivrosAppContext context) : base(context) { }
    }
}
