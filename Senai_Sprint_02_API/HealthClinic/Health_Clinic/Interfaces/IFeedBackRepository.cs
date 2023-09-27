using Health_Clinic.Domains;

namespace Health_Clinic.Interfaces
{
    public interface IFeedBackRepository
    {
        void Cadastrar(FeedBack feedBack);

        void Deletar(Guid id);

        List<FeedBack> Listar();
    }
}
