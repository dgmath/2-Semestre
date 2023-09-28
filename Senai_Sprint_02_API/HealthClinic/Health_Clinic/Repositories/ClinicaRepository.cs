using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Interfaces;

namespace Health_Clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthContext;

        public ClinicaRepository()
        {
            _healthContext = new HealthClinicContext();
        }
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthContext.Clinica.Add(clinica);

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
                Clinica clinicaBuscada = _healthContext.Clinica.Find(id);

                if (clinicaBuscada != null)
                {
                    _healthContext.Clinica.Remove(clinicaBuscada);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
