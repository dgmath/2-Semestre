using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Interfaces;
using Health_Clinic.Utils;

namespace Health_Clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthClinicContext();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }

                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool conferir = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (conferir == true)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healthContext.Usuario.Add(usuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    _healthContext.Usuario.Remove(usuarioBuscado);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
