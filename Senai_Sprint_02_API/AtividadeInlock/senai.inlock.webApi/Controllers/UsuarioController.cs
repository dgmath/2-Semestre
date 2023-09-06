using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Nenhum Usuário foi encontrado");
                }

                //Casao encontre o usuario bsucado, prossegue para a criação do token

                //1º - Definir as informações(Claims) que serão fornecidos no token (Payload)

                var claims = new[]
                {
                    //formato da claim(tipo,valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.IdUsuario.ToString()),

                    new Claim(JwtRegisteredClaimNames.Email,usuarioEncontrado.Email),

                    new Claim(ClaimTypes.Role,usuarioEncontrado.IdTipoUsuario.ToString()),

                    new Claim("Claim Personalizada", "Valor Personalizado")

                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar o token
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.filmes",

                    //destinatario
                    audience: "webapi.filmes",

                    //dados definidos nas claims (Payload)
                    claims: claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds
                );

                //5º - retornar o token criado

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
