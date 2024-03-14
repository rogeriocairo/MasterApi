namespace MasterApi.Core.Interface.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        public Task Add(TEntity _entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(int id);
        Task Update(TEntity rota);
        Task Delete(int id);
    }
}
