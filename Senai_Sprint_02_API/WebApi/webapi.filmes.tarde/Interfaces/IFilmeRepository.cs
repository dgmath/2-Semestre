using webapi.filmes.tarde.Domains;


namespace webapi.filmes.tarde.Interfaces
{
    public interface IFilmeRepository
    {
        //CRUD 

        /// <summary>
        /// Cadastrar um novo Filme
        /// </summary>
        /// <param name="novoFilme">Objeto que sera cadastrado</param>
        void CadastrarFilme(FilmeDomain novoFilme);

        /// <summary>
        /// Retornar todos os filmes cadastrados
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodosFilmes();

        /// <summary>
        /// Buscar um objeto pelo seu id
        /// </summary>
        /// <param name="id">id do objeto que sera buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        FilmeDomain BuscaPorId(int id);

        /// <summary>
        /// Atualizar um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <param name="filme">Objeto com as novas informações</param>
        void AtualizarFilmeUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto com as novas informações</param>
        void AtualizarComId(FilmeDomain filme);

        /// <summary>
        /// Deleta um filme existente pelo seu id
        /// </summary>
        /// <param name="id">id do objeto a ser deletado</param>
        void DeletarComId(int id);
    }
}
