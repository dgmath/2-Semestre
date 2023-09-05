using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TiposUsuarioDomain
    {
        public int IdTiposUsuario { get; set; }

        [Required(ErrorMessage = "O titulo do Tipo de Usuario é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
