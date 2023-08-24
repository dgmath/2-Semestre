using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os seguintes parametros:
        /// Data Source : Nome do servidor do Banco
        /// Initial Catalog: Nome do Banco de Dados
        /// Autenticação
        ///     -Windows : Integrated Security: True
        ///     -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE15-S14; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SqlConnection usando da sting de conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (' " + novoGenero.Nome + " ')";

                
                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar Todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista de objetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos onde serão armazenados os generos
            List <GeneroDomain> listaGeneros= new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // DECLARA a instrução a ser executada (SELECT)
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //ABRE a conexão com o banco de dados
                con.Open();

                //DECLARA o SqlDataReader para percorrer(ler) a tabela no banco de dados 
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexao
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    //EXECUTA a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //ENQUANTO houver registros para serem lidos no rdr o laço se repetira
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //ATRIBUI a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //ATRIBUI a propriedade Nome o valor da primeira coluna
                            Nome = rdr["Nome"].ToString()
                        };

                        listaGeneros.Add(genero);

                    }
                }
            }

            return listaGeneros;
        }
    }
}
