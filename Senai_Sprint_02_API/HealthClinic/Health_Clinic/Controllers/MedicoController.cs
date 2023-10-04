﻿using Health_Clinic.Domains;
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
    //[Authorize]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController() 
        {
            _medicoRepository = new MedicoRepository();
        }

        [HttpPost("Cadastrar")]
       // [Authorize(Roles = "Administrador")]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return StatusCode(201);
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarPorId")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMinhasConsultas")]
        //[Authorize(Roles = "Administrador")]
        //[Authorize(Roles = "Médico")]
        public IActionResult Get(string nomeMedico)
        {
            try
            {
                List<Consulta> listarConsulta = _medicoRepository.ListarMinhasConsultas(nomeMedico);

                return Ok(listarConsulta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
