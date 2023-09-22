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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _comentarioEventoRepository { get; set; }

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);

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
                _comentarioEventoRepository.Deletar(id);

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
                List<ComentarioEvento> listaComentario = _comentarioEventoRepository.Listar();

                return Ok(listaComentario);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("BuscarPorId")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("Atualizar")]

        public IActionResult Put(Guid id, ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Atualizar(id, comentarioEvento);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
