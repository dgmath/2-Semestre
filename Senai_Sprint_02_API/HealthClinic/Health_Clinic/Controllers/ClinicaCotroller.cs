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
    public class ClinicaCotroller : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaCotroller()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarComId")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
