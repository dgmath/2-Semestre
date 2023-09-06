using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE15-S14; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134"; 
        public void CadastrarJogo(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES (@IdEstudio,@Nome,@Descricao,@DataLancamento,@Valor)";
            
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);

                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);

                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);

                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarComId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarJogos()
        {
            List<JogoDomain> listarJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Jogo.IdJogo, Jogo.IdEstudio, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Estudio.Nome AS nomeEstudio FROM Jogo INNER JOIN Estudio on Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            Nome = rdr["Nome"].ToString(),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToInt32(rdr["Valor"]),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["nomeEstudio"].ToString()
                            }

                        };

                        listarJogos.Add(jogo);
                    }
                }
            }
            return listarJogos;
        }
    }
}
