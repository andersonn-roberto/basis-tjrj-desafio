using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(LivrosAppContext context) : base(context) { }
    }
}
