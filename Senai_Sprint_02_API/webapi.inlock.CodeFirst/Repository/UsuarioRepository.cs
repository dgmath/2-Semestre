using webapi.inlock.CodeFirst.Contexts;
using webapi.inlock.CodeFirst.Domains;
using webapi.inlock.CodeFirst.Intefaces;
using webapi.inlock.CodeFirst.Utils;

namespace webapi.inlock.CodeFirst.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;
        public UsuarioRepository() 
        {
            ctx = new InlockContext();
        }
        public Usuario Login(string email, string senha)
        {
            try
            {
                var login = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (login != null)
                {
                    bool confere = Criptografia.CompararHash(senha, login.Senha!);

                    if (confere)
                    {
                        return login;
                    }      
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        void IUsuarioRepository.Cadastrar(Usuario usuario)
        {
            try
            {
               usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
