using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]

        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VACHAR(100)")]
        [Required(ErrorMessage = "O Tipo de Usuario é obrigatorio")]
        public string? Titulo { get; set; }
    }
}
