using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereco da Clinica é obrigatório!")]
        public string Endereco { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ da Clinica é obrigatório!")]
        public string CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O NomeFantasia da Clinica é obrigatório!")]
        public string NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O RazaoSocial da Clinica é obrigatório!")]
        public string RazaoSocial { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "O HorarioFuncionamento da Clinica é obrigatório!")]
        public DateTime HorarioFuncionamento { get; set; }
    }
}
