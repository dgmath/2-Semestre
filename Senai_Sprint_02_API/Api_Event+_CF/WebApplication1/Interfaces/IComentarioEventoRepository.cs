using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        void Deletar(Guid id);

        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Guid comentarioEvento);
    }
}
