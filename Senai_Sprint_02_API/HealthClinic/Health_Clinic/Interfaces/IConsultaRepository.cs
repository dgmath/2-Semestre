using Health_Clinic.Domains;

namespace Health_Clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        void AtualizarProntuario(Guid id, Consulta consulta);

        List<Consulta> Listar();
    }
}
