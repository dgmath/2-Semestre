using Health_Clinic.Domains;
using Health_Clinic.Interfaces;
using Health_Clinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
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
                _pacienteRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMinhasConsultas")]
        public IActionResult Get(string nomePaciente)
        {
            try
            {
                List<Consulta> listarConsulta = _pacienteRepository.ListarMinhasConsultas(nomePaciente);

                return Ok(listarConsulta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
