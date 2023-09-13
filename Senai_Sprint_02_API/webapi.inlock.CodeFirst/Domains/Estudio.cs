using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]

        [Required(ErrorMessage = "Nome Obrigatório")]
        public string? Nome { get; set; }

        //ref. lista jogos
        public List<Jogo> jogo { get; set; }
    }
}
