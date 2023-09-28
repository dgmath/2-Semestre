using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Interfaces;

namespace Health_Clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthContext;

        public ConsultaRepository()
        {
            _healthContext = new HealthClinicContext();
        }

        public void AtualizarProntuario(Guid id, Consulta consulta)
        {
            try
            {
                Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;

                if (consultaBuscada != null)
                {
                    consultaBuscada.Prontuario = consulta.Prontuario;
                }

                _healthContext.Consulta.Update(consultaBuscada!);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthContext.Consulta.Add(consulta);

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
                Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;

                if (consultaBuscada != null)
                {
                    _healthContext.Consulta.Remove(consultaBuscada);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> Listar()
        {
            try
            {
                return _healthContext.Consulta.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
