using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(LivrosAppContext context) : base(context) { }
    }
}
