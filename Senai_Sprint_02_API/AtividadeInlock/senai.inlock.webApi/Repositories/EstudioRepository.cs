using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE15-S14; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        public void CadastrarEstudio(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome), VALUES(@Nome)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarEstudio()
        {
            List<EstudioDomain> listarEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio,Nome From Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["nomeEstudio"].ToString()

                        };

                        listarEstudios.Add(estudio);
                    }
                }
            }
            return listarEstudios;
        }

        public List<EstudioDomain> ListarComJogos() 
        {
            List<EstudioDomain> listarEstudios = new List<EstudioDomain>();

            using (SqlConnection conEstudios = new SqlConnection(StringConexao))
            {
                string querySelectAll = "Select IdEstudio, Nome FROM Estudio";

                conEstudios.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll,conEstudios))
                {
                    SqlDataReader rdrEstudio = cmd.ExecuteReader();

                    while (rdrEstudio.Read())
                    {
                        List<JogoDomain> listaJogos = new List<JogoDomain>();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdrEstudio["IdEstudio"]),

                            Nome = rdrEstudio["Nome"].ToString()

                        };

                        using (SqlConnection conJogos = new SqlConnection(StringConexao))
                        {
                            string querySelectAllJogos = "SELECT IdJogo ,Nome,Descricao,DataLancamento, Valor FROM Jogo WHERE IdEstudio = @IdEstudio";

                            conJogos.Open();

                            using (SqlCommand cmdJogos = new SqlCommand(querySelectAllJogos, conJogos))
                            {
                                cmdJogos.Parameters.AddWithValue("@IdEstudio", estudio.IdEstudio);

                                SqlDataReader readerJogos = cmd.ExecuteReader();

                                while (readerJogos.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        IdJogo = Convert.ToInt32(readerJogos["IdJogo"]),

                                        Nome = readerJogos["Nome"].ToString(),

                                        Descricao = readerJogos["Descricao"].ToString(),

                                        DataLancamento = Convert.ToDateTime(readerJogos["DataLancamento"]),

                                        Valor = Convert.ToInt32(readerJogos["Valor"])
                                    };
                                    listaJogos.Add(jogo);
                                }
                            }
                            estudio.ListaJogos = listaJogos;

                            listarEstudios.Add(estudio);
                        }
                    }
                }
            }
            return listarEstudios;
        }
    }
}
