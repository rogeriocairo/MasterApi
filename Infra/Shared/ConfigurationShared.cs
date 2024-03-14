namespace Stocks.Api.Infra.Shared
{
    public class ConfigurationShared
    {
        private readonly IConfiguration _configuration;

        public ConfigurationShared(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetChave(string chave)
        {
            var valor = _configuration.GetSection(chave);

            return valor == null ? "" : valor.Value;           
        }   
        
    }
}
