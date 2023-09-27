using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(FeedBack))]
    public class FeedBack
    {
        [Key]
        public Guid IdFeedBack { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A Descrição é obrigatória!")]
        public string Descricao { get; set; }

        //ref. Tabela Consulta = FK
        [Required(ErrorMessage = "A consulta é obrigatória!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

    }
}
