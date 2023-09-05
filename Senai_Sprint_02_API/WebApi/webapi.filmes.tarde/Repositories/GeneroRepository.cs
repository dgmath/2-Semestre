using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
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
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string queryUpdate = "Update Genero SET Nome = @Nome  WHERE IdGenero = @id";

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {

                        cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                        cmd.Parameters.AddWithValue("@id", genero.IdGenero);

                    //Abre a conexao com o banco de dados
                    con.Open();

                        //Executa a query
                        cmd.ExecuteNonQuery();
                    }
                }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Genero.Nome = @Nome WHERE Genero.IdGenero = @id";

                //Abre a conexao com o banco de dados
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);



                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public GeneroDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // DECLARA a instrução a ser executada (SELECT)
                string querySelectGenero = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectGenero,con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    //ABRE a conexão com o banco de dados
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                        {
                            GeneroDomain generoEncontrado = new GeneroDomain()
                            {
                                //ATRIBUI a propriedade IdGenero o valor da primeira coluna da tabela
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                //ATRIBUI a propriedade Nome o valor da primeira coluna
                                Nome = rdr["Nome"].ToString()
                            };
                             return generoEncontrado;
                        }
                    

                return null;
                }
            }
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
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @idGenero";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@idGenero", id);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
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
