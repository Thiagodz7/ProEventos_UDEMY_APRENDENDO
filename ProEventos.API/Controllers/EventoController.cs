using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.DTOs;
using ProEventos.Application.IQueries;
using System;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        private readonly IEventosService _eventosServices;
        public EventoController (IEventosService eventosServices)
        {
            _eventosServices = eventosServices;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var eventos = await _eventosServices.GetAllEventosAsync(true);
                if (eventos == null)
                    return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar eventos. Erro:{ex.Message}");
            }            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var eventos = await _eventosServices.GetEventoByIdAsync(id, true);
                if (eventos == null)
                    return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<ActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _eventosServices.GetEventosByTemaAsync(tema, true);
                if (eventos == null)
                    return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto evento) 
        {
            try
            {
                var eventos = await _eventosServices.AddEventos(evento);
                if (eventos == null)
                    return BadRequest("Erro ao tentar adicionar Evento.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar eventos. Erro:{ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, EventoDto evento)
        {
            try
            {
                var eventos = await _eventosServices.UpdateEvento(id, evento);
                if (eventos == null)
                    return BadRequest("Erro ao tentar alterar Evento.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar alterar eventos. Erro:{ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //If Ternário
                return await _eventosServices.DeleteEvento(id) ?
                             Ok("Deletado com Sucesso.") : 
                             BadRequest("Não foi Deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro:{ex.Message}");
            }
        }

    }
}
