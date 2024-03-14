using MasterApi.Core.Entity;
using MasterApi.Core.Interface.Repository;
using Stocks.Api.Core.Repository;
using Stocks.Core.Interface.Repository;
using Stocks.Infra.Data.Context;

namespace MasterApi.Core.Repository
{
    public class RotaRepository : RepositoryBase<RotaEntity>, IRotaRepository
    {
        public RotaRepository(DataContext context) : base(context)
        {
        }
                
    }
}
