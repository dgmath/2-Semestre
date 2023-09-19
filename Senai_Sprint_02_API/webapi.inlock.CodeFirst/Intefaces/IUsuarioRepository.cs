using webapi.inlock.CodeFirst.Domains;

namespace webapi.inlock.CodeFirst.Intefaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        public void Cadastrar(Usuario usuario);
    }
}
