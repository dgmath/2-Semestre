using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo é Obrigatório")]
        public string Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é Obrigatória")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A Data é Obrigatória")]
        public DateTime DataLancamento { get; set; }
        
        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "O Valor é Obrigatório")]
        public decimal Preco { get; set; }

        //ref.tabela estudio - FK

        public Guid IdEstudio { get; set; }

        [ForeignKey(("IdEstudio"))]
        public Estudio? Estudio { get; set; }
    }
}
