using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Interfaces;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;
        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento peventoBuscado = _eventContext.PresencaEventos.FirstOrDefault(e => e.IdPresencaEvento == id)!;

            if (peventoBuscado != null)
            {
                peventoBuscado.Situacao = presencaEvento.Situacao;
            }
            _eventContext.PresencaEventos.Update(peventoBuscado);

            _eventContext.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            return _eventContext.PresencaEventos.FirstOrDefault(e => e.IdPresencaEvento == id)!;
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            try
            {
                _eventContext.PresencaEventos.Add(presencaEvento);

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
                PresencaEvento peventoBuscado = _eventContext.PresencaEventos.Find(id)!;

                if (peventoBuscado != null)
                {
                    _eventContext.PresencaEventos.Remove(peventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> ListarMinhasPresencas(Guid id)
        {
            try
            {
                return _eventContext.PresencaEventos.Where(e => e.IdUSuario == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                return _eventContext.PresencaEventos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
