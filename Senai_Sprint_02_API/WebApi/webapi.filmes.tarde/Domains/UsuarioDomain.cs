using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O email é obrigatório!")]

        public string Senha { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]

        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório!")]
        public bool Permissao { get; set; } 
    }
}
