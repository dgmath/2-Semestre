using Health_Clinic.Domains;

namespace Health_Clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Guid id);

        List<Consulta> ListarMinhasConsultas(string nomePaciente);
    }
}
