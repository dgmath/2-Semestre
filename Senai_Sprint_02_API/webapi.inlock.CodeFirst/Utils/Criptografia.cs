namespace webapi.inlock.CodeFirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir da senha
        /// </summary>
        /// <param name="senha">Senha que receberá a hash</param>
        /// <returns>Senha criptografada com a hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada e igual a hash salva no bd
        /// </summary>
        /// <param name="senhaForm"></param>
        /// <param name="senhaBanco"></param>
        /// <returns></returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
