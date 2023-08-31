using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario, Email, Senha, Nome, Permissao FROM Usuario WHERE Email = @email AND Senha = @senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr["Email"].ToString(),



                            Nome = rdr["Nome"].ToString(),

                            Permissao = Convert.ToBoolean(rdr["Permissao"]),
                        };

                        return usuarioEncontrado;
                    }
                    return null;
                }

            }
        }
    }
}
