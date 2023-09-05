using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição  sera no seguinte formato 
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de api 
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da api é JSON
    /// </summary>
    [Produces("application/json")]

    //[Authorize] desta forma se aplica a todos os http
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que ira receber os metdos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia do objeto _generoRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o metodo de listar os generos
        /// </summary>
        /// <returns>Lista de generos e um statuscode</returns>
        [HttpGet]
        [Authorize]//precisa estar logado para acesssar a rota
        public IActionResult Get()
        {
            try
            {
                //Foi criada uma lista para receber os generos
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //Retorna o statuscode 200 ok e a listaGeneros no formato JSON 
                return Ok(listaGeneros);
                //return StatusCode(200,listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um statuscode 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
               GeneroDomain generoEncontrado = _generoRepository.BuscarPorId(id);

                if (generoEncontrado == null)
                {
                    return NotFound("O genero buscado nao foi encontrado");
                }

                return Ok(generoEncontrado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o metodo de cadastrar genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido a requisicao</param>
        /// <returns>StatusCode(201)</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Faz a chamada do metodo cadastrar
                _generoRepository.Cadastrar(novoGenero);

                //Retorna um status code
                return Created("Objeto criado", novoGenero);
                //return StatusCode(201, novoGenero);
            }
            catch (Exception erro)
            {
                //Retorna o status code BadRequest (400) e a mensagem de erros
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204, id);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, genero);

                return Ok(genero);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message); 
            }
        }

        [HttpPut]
        public IActionResult Put(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);

                        return NoContent();
                    }

                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                    
                }
                 return NotFound("Genero não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
