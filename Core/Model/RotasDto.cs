namespace MasterApi.Core.Model
{
    public class RotasDto
    {
        public RotasDto(string origem, string destino)
        {
            Origem = origem;
            Destino = destino;           
        }

        public required string Origem { get; set; }
        public required string Destino { get; set; }
    }
}
