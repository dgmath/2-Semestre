using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade ou tabela filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O titulo do filme é obrigatório!")]

        public int IdGenero { get; set; }

        //Referencia para a classe genero
        public GeneroDomain? Genero { get; set; }

    }
}
