using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Prontuario { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "A Data de Agendamento da Consulta é obrigatório!")]
        public DateTime DataAgendamento { get; set; }

        //ref. tabela Usuario = FK

        [Required(ErrorMessage = "O Paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref. tabela Clinica = Fk
        [Required(ErrorMessage = "O Médico é obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //ref. Tabela Especialidade = Fk
        [Required(ErrorMessage = "A Situação é obrigatória!")]
        public Guid IdSituacao { get; set; }

        [ForeignKey(nameof(IdSituacao))]
        public Situacao? Situacao { get; set; }
    }
}
