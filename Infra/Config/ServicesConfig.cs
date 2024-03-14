using MasterApi.Core.Interface.Repository;
using MasterApi.Core.Interface.Services;
using MasterApi.Core.Repository;
using MasterApi.Core.Service;
using Stocks.Infra.Data.Context;

namespace Stocks.Api.Infra.Config
{
    public static class ServicesConfig
    {
        public static void AddServices (IServiceCollection services)
        {
            // Add services to the container.
            services.AddTransient<IRotaService, RotaService>();
                        
            services.AddScoped<IRotaRepository, RotaRepository>();           
            
            
            services.AddScoped<DataContext>();

        }
    }
}
