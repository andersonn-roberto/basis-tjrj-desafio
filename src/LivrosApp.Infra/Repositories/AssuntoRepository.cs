using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class AssuntoRepository : BaseRepository<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(LivrosAppContext context) : base(context) { }
    }
}
