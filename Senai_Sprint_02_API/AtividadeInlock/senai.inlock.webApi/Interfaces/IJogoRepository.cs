using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        void CadastrarJogo(JogoDomain novoJogo);

        List<JogoDomain> ListarJogos();

        void DeletarComId(int id);
    }
}
