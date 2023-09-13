using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email Obrigatório!")]
        []
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha Obrigatório!")]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "A Senha deve conter de 6 a 20 caracteres!")]
        public string? Senha { get; set; }
    }
}
