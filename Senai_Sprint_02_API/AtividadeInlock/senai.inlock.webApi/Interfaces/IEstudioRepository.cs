using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        void CadastrarEstudio(EstudioDomain novoEstudio);

        List<EstudioDomain> ListarEstudio();

        List<EstudioDomain> ListarComJogos();
    }
}
