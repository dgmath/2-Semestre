using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario UsuarioBuscarPorEmailSenha(string email, string senha);

    }
}
