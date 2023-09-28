using Health_Clinic.Domains;

namespace Health_Clinic.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);

        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
