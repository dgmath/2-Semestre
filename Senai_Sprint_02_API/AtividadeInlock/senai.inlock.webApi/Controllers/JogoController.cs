using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }

        public JogoController() 
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                List<JogoDomain> listarJogos = _jogoRepository.ListarJogos();
                
                return Ok(listarJogos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain novoJogo) 
        {
            try
            {
                _jogoRepository.CadastrarJogo(novoJogo);
                return Created("Objeto criado", novoJogo);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.DeletarComId(id);

                return StatusCode(204, id);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
