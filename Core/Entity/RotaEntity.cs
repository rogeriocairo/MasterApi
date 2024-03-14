namespace MasterApi.Core.Entity
{
    public class RotaEntity
    {
        public int Id { get; set; }
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public decimal Valor { get; private set; }

        public RotaEntity(int id = 0, string origem = "", string destino = "", decimal valor = 0)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
    }
}
