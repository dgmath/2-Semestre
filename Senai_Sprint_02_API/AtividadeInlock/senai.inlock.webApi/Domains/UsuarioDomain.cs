using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuario é obrigatório!")]
        public string? Email { get; set;}

        [Required(ErrorMessage = "A senha do usuario é obrigatória!")]
        public string? Senha { get; set;}
    }
}
