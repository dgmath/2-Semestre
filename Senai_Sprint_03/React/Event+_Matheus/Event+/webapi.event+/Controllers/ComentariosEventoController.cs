using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosEventoController : ControllerBase
    {
        //acesso aos métodos do repositório
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //armazena dados da api externa
        private readonly ContentModeratorClient _contentModeratorClient;

        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }


        [HttpPost("PostWithIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento comentariosEvento)
        {
            try
            {
                //Validação: se a descrição do comentário não for passado no objeto
                if (string.IsNullOrEmpty(comentariosEvento.Descricao))
                {
                    return BadRequest("O texto validado não pode se encontrar como vazio!");
                }

                //converte a descrição do comentário em um MemoryStream (transmissão)
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentariosEvento.Descricao));

                //Realiza a moderação do conteúdo (descrição do comentário)
                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream,"por", false, false, null, true);

                //se existir termos ofensivos
                if (moderationResult.Terms != null)
                {
                    //atribuir false para exibe
                    comentariosEvento.Exibe = false;

                    //cadastra o comentário
                    comentario.Cadastrar(comentariosEvento);
                }
                else
                {
                    comentariosEvento.Exibe = true;

                    comentario.Cadastrar(comentariosEvento);
                }
                return StatusCode(201, comentariosEvento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetIA(Guid id)
        {
            try
            {
                return Ok(comentario.ListarSomenteExibe(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id) 
        {
            try
            {
                return Ok(comentario.Listar(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByUserId(Guid idUsuario, Guid idEvento) 
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ComentariosEvento novoComentario) 
        {
            try
            {
                comentario.Cadastrar(novoComentario);
                return StatusCode(201, novoComentario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
