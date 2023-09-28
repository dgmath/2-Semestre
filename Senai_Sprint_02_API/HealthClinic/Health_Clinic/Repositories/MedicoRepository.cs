using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Interfaces;

namespace Health_Clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthContext;

        public MedicoRepository()
        {
            _healthContext = new HealthClinicContext();
        }
        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthContext.Medico.Add(medico);

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
                Medico medicoBuscado = _healthContext.Medico.Find(id);

                if (medicoBuscado != null)
                {
                    _healthContext.Medico.Remove(medicoBuscado);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasConsultas(string nomeMedico)
        {
            try
            {
                return _healthContext.Consulta.Where(e => e.Medico.Nome == nomeMedico).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
