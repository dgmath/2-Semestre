using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Interfaces;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {

        private readonly EventContext _eventContext;
        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.TipoEvento = evento.TipoEvento;
                eventoBuscado.Instituicao = evento.Instituicao;
            }
            _eventContext.Evento.Update(eventoBuscado);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

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
                Evento eventoBuscado = _eventContext.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _eventContext.Evento.Remove(eventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _eventContext.Evento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
