using MasterApi.Core.Entity;
using MasterApi.Core.Model;

namespace MasterApi.Core.Interface.Services
{
    public interface IRotaService : IServiceBase<RotaModel>
    {
        public Task<string> CaminhoMaisEconomicoAsync(RotasDto rotas);
    }
}
