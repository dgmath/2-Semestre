using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do Paciente é obrigatório!")]
        public string Nome { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O CPF do Paciente é obrigatório!")]
        public string CPF { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "A Data de Nascimento da Clinica é obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "INT")]
        [Required(ErrorMessage = "O Telefone do Paciente é obrigatório!")]
        public int Telefone { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Endereço do Paciente é obrigatório!")]
        public string Endereco { get; set; }

        //ref. Tabela Usuario = FK

        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
