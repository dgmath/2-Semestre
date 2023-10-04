using Health_Clinic.Domains;
using Health_Clinic.Interfaces;
using Health_Clinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
   // [Authorize]
    public class FeedBackController : ControllerBase
    {
        private IFeedBackRepository _feedbackRepository { get; set; }

        public FeedBackController()
        {
            _feedbackRepository = new FeedBackRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(FeedBack feedback)
        {
            try
            {
                _feedbackRepository.Cadastrar(feedback);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarComId")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _feedbackRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarTodos")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                List<FeedBack> listarFeedBack = _feedbackRepository.Listar();

                return Ok(listarFeedBack);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
