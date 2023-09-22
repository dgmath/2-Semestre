using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        void Deletar(Guid id);

        List<ComentarioEvento> Listar();

        ComentarioEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, ComentarioEvento comentarioEvento);
    }
}
