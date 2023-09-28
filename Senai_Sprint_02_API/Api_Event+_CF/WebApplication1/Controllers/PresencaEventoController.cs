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
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaeventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaeventoRepository = new PresencaEventoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaeventoRepository.Cadastrar(presencaEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarPorId")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaeventoRepository.Deletar(id);

                return NoContent();
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
                List<PresencaEvento> listapresencaEvento = _presencaeventoRepository.Listar();

                return Ok(listapresencaEvento);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("ListarMinhasPresencas")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<PresencaEvento> listarMinhasPresencas = _presencaeventoRepository.ListarMinhasPresencas(id);

                return Ok(listarMinhasPresencas);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaeventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("Atualizar")]

        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                _presencaeventoRepository.Atualizar(id, presencaEvento);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
