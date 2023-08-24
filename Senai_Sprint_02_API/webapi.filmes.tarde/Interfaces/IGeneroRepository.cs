using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositório GEneroRepository
    /// Define os metodos que serao implementados pelo repositorio
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        //TipoDeRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto que sera cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os generos cadastrados
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto pelo seu id
        /// </summary>
        /// <param name="id">id do objeto que sera buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um genero existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um genero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um genero existente pelo seu id
        /// </summary>
        /// <param name="id">id do objeto a ser deletado</param>
        void Deletar(int id);


    }
}
