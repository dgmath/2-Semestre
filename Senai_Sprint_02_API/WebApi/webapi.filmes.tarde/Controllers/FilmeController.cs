using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    /// <summary>
    /// Define que o tipo de resposta da api é JSON
    /// </summary>
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodosFilmes();

                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscaPorId(id);

                if (filmeEncontrado == null)
                {
                    return NotFound("O filme buscado não foi encontrado");
                }

                return Ok(filmeEncontrado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.CadastrarFilme(novoFilme);

                return Created("Objeto criado", novoFilme);
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
                _filmeRepository.DeletarComId(id);

                return StatusCode(204, id);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(FilmeDomain novoFilme)
        {
            try
            {
                FilmeDomain generoBuscado = _filmeRepository.BuscaPorId(novoFilme.IdFilme);

                if (generoBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarComId(novoFilme);

                        return NoContent();
                    }

                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }

                }
                return NotFound("Filme não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarFilmeUrl(id, filme);

                return Ok(filme);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
