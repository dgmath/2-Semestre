using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        private string StringConexao = "Data Source = NOTE15-S14; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";
        public List<FilmeDomain> ListarTodosFilmes()
        {

            //Cria uma lista de generos onde serão armazenados os generos
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Genero.IdGenero, Filme.Titulo, Genero.Nome FROM Filme INNER JOIN Genero on Filme.IdGenero = Genero.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr[1]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),

                                Nome = rdr["Nome"].ToString()
                            }

                        };

                        listaFilmes.Add(filme);

                    }
                }
            }
            return listaFilmes;
        }

        public void CadastrarFilme(FilmeDomain novoFilme)
        {
            //Declara a SqlConnection usando da sting de conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Filme(IdGenero,Titulo) VALUES (@IdGenero,@Titulo)";

                //Abre a conexão
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public void AtualizarComId(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "Update Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@id", filme.IdFilme);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarFilmeUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filme SET FIlme.Titulo = @Titulo, Filme.IdGenero = @IdGenero WHERE Filme.IdFilme = @id";

                //Abre a conexao com o banco de dados
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);



                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscaPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // DECLARA a instrução a ser executada (SELECT)
                string querySelectFilme = "SELECT IdFilme, Genero.IdGenero, Titulo, Nome FROM Filme INNER JOIN Genero on Filme.IdGenero = Genero.IdGenero WHERE IdFilme = @IdFilme";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectFilme, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    //ABRE a conexão com o banco de dados
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeEncontrado = new FilmeDomain()
                        {
                            //ATRIBUI a propriedade IdFilme o valor da primeira coluna da tabela
                            IdFilme = Convert.ToInt32(rdr["IdFIlme"]),

                            //ATRIBUI a propriedade Nome o valor da primeira coluna
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr[1]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),

                                Nome = rdr["Nome"].ToString()
                            }

                        };
                        return filmeEncontrado;
                    }


                    return null;
                }
            }
        }

        public void DeletarComId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}