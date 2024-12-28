using LivrosApp.Dominio.Interfaces;
using LivrosApp.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LivrosApp.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly LivrosAppContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(LivrosAppContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new InvalidOperationException("Entity not found");
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
