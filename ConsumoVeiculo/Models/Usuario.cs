using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoVeiculo.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informar o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informar a senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informar o perfil de usuário.")]
        public Perfil Perfil { get; set; }
    }

    public enum Perfil
    {
        Admin,
        User
    }
}
