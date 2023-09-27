using Health_Clinic.Domains;

namespace Health_Clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        List<Consulta> ListarMinhasConsultas(string nomeMedico);
    }
}
