using Microsoft.EntityFrameworkCore;
using Stocks.Core.Interface.Repository;
using Stocks.Infra.Data.Context;

namespace Stocks.Api.Core.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            var _registro = await _dbSet.FindAsync(id);
            return _registro ?? default;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var _registros = await _context.Set<TEntity>().ToListAsync();
            return _registros;
        }

        public async Task<int> UpdateAsync(TEntity entity, int id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entityInDb = _dbSet.Find(id)
                ?? throw new Exception("Entity not found in database");
            
            _context.Entry(entityInDb).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
        }
    }
}