namespace Stocks.Core.Interface.Repository;

public interface IRepository<TEntity> where TEntity : class
{ 
    public Task AddAsync(TEntity entity);

    public Task<int> UpdateAsync(TEntity entity, int id);

    public Task DeleteAsync(TEntity entity);    

    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task<TEntity?> GetAsync(int id);
}