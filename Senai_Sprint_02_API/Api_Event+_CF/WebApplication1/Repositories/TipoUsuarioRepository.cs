using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Interfaces;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        { 
            _eventContext= new EventContext();
        } 
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = _eventContext.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
            }
            _eventContext.TipoUsuario.Update(tipoUsuarioBuscado);

            _eventContext.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
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
                TipoUsuario tUsuarioBuscado = _eventContext.TipoUsuario.Find(id)!;

                if (tUsuarioBuscado != null)
                {
                    _eventContext.TipoUsuario.Remove(tUsuarioBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _eventContext.TipoUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
