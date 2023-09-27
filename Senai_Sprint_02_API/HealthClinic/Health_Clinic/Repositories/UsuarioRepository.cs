using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Utils;

namespace Health_Clinic.Repositories
{
    public class UsuarioRepository
    {
        private readonly HealthClinicContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthClinicContext();
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
