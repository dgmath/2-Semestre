using webapi.event_.tarde.Interfaces;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        public void Atualizar(Guid id, Guid comentarioEvento)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
