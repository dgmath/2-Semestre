using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Interfaces;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;
        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscado = _eventContext.Instituicao.FirstOrDefault(e => e.IdInstituicao == id)!;

            if (instituicaoBuscado != null)
            {
                instituicaoBuscado.CNPJ = instituicao.CNPJ;
                instituicaoBuscado.Endereco = instituicao.Endereco;
                instituicaoBuscado.NomeFantasia = instituicao.NomeFantasia;
            }
            _eventContext.Instituicao.Update(instituicaoBuscado);

            _eventContext.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            return _eventContext.Instituicao.FirstOrDefault(e => e.IdInstituicao == id)!;
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao);

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
                Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(id)!;

                if (instituicaoBuscado != null)
                {
                    _eventContext.Instituicao.Remove(instituicaoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        List<Instituicao> IInstituicaoRepository.Listar()
        {
            try
            {
                return _eventContext.Instituicao.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
