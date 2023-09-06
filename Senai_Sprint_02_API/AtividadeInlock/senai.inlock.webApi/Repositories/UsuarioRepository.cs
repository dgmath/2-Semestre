using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE15-S14; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuario WHERE Email = @email AND Senha = @senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr["Email"].ToString(),

                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                        };

                        return usuarioEncontrado;
                    }
                    return null;
                }

            }
        }
    }
}
