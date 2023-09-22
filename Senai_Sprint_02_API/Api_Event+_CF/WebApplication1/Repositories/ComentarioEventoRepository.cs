using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Interfaces;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;
        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {
            ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.FirstOrDefault(e => e.IdComentarioEveto == id)!;

            if (comentarioBuscado != null)
            {
                comentarioBuscado.Descricao = comentarioBuscado.Descricao;
                comentarioBuscado.Exibe = comentarioBuscado.Exibe;
                comentarioBuscado.Usuario = comentarioBuscado.Usuario;
                comentarioBuscado.Evento = comentarioBuscado.Evento;
            }
            _eventContext.ComentarioEvento.Update(comentarioBuscado);

            _eventContext.SaveChanges();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            return _eventContext.ComentarioEvento.FirstOrDefault(e => e.IdComentarioEveto == id)!;
        }
    

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

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
                ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.Find(id)!;

                if (comentarioBuscado != null)
                {
                    _eventContext.ComentarioEvento.Remove(comentarioBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
               return _eventContext.ComentarioEvento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
