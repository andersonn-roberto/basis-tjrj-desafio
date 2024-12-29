using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class LivroAssuntoRepository : BaseRepository<LivroAssunto>, ILivroAssuntoRepository
    {
        public LivroAssuntoRepository(LivrosAppContext context) : base(context) { }
    }
}
