using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Cadastrar(PresencaEvento presencaEvento);

        void Deletar(Guid id);

        List<PresencaEvento> Listar();

        List<PresencaEvento> ListarMinhasPresencas(Guid id);

        PresencaEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, PresencaEvento presencaEvento);
    }
}
