using System.ComponentModel.DataAnnotations;

namespace MasterApi.Core.Model
{
    public class RotaModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "Origem - Tamanho máximo é de 3")]
        public required string Origem { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "Destino - Tamanho máximo é de 3")]
        public required string Destino { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Valor - O valor deve ser maior que zero!")]
        public decimal Valor { get; set; }
    }
}
