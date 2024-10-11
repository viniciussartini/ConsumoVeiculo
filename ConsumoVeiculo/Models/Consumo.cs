using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoVeiculo.Models
{
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informar a descrição.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informar a data.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informar o valor.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Informar a quilometragem.")]
        public int Km { get; set; }

        [Display(Name = "Tipo de combustível")]
        public TipoCombustivel Tipo { get; set; }

        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "Informar a veículo.")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
    }

    public enum TipoCombustivel
    {
        Gasolina,
        Etanol
    }
}
