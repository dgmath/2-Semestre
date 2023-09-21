using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_tarde.Domains;

namespace webapi.event_.tarde.Controllers
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
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(208);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarTodos")]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> listaUsuario = _usuarioRepository.Listar();

                return Ok(listaUsuario);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("BuscarPorEmaileSenha")]
        public IActionResult Get(string email,string senha)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorEmailSenha(email, senha));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
