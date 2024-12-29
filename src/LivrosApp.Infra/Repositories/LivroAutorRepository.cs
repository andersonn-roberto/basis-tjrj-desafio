using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class LivroAutorRepository : BaseRepository<LivroAutor>, ILivroAutorRepository
    {
        public LivroAutorRepository(LivrosAppContext context) : base(context) { }
    }
}
