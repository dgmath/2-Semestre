﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.CodeFirst.Domains;
using webapi.inlock.CodeFirst.Intefaces;
using webapi.inlock.CodeFirst.Repository;
using webapi.inlock.CodeFirst.ViewModel;

namespace webapi.inlock.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel logaUsuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(logaUsuario.Email!, logaUsuario.Senha!);
                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou Senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, usuarioBuscado.Email!)
                };



                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-key-webapi"));


                var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "webapi-inlock",
                        
                    audience: "webapi-inlock",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(3),

                    signingCredentials: creds

                );



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
