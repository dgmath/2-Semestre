using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        List<Usuario> Listar();

        Usuario BuscarPorEmailSenha(string email, string senha);

    }
}
