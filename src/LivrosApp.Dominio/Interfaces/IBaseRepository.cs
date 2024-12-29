using System.Linq.Expressions;

namespace LivrosApp.Dominio.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string includeProperties = "");
        Task Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Remove(T entity);
    }
}
