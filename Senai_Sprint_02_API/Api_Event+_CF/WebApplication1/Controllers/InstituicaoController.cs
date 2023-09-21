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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Instituicao inst)
        {
            try
            {
                _instituicaoRepository.Cadastrar(inst);

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
                _instituicaoRepository.Deletar(id);

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
                List<Instituicao> listaInstituicao = _instituicaoRepository.Listar();

                return Ok(listaInstituicao);
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
                return Ok(_instituicaoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("Atualizar")]

        public IActionResult Put(Guid id, Instituicao inst)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, inst);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
