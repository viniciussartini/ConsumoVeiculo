using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoVeiculo.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do veículo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a placa do veículo.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Informe o ano de fabricação do veículo.")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Informe o ano do modelo do veículo.")]
        public int AnoModelo { get; set; }
    }
}
