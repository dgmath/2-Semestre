using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Interfaces;

namespace Health_Clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthContext;

        public PacienteRepository()
        {
            _healthContext = new HealthClinicContext();
        }
        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthContext.Paciente.Add(paciente);

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
                Paciente pacienteBuscado = _healthContext.Paciente.Find(id);

                if (pacienteBuscado != null)
                {
                    _healthContext.Paciente.Remove(pacienteBuscado);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasConsultas(string nomePaciente)
        {
            try
            {
                return _healthContext.Consulta.Where(e => e.Paciente.Nome == nomePaciente).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
