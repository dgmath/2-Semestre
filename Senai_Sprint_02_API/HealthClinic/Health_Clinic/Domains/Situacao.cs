using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Situacao))]
    public class Situacao
    {
        [Key]
        public Guid IdSituacao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O titulo da Situação é obrigatório!")]
        public string Titulo { get; set; }
    }
}
