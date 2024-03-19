using CogeconAPI.Interfaces;
using CogeconAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CogeconAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadeConsumidoraController : ControllerBase
    {
        private readonly IUnidadeConsumidoraService _unidadeConsumidoraService;

        public UnidadeConsumidoraController(IUnidadeConsumidoraService unidadeConsumidoraService)
        {
            _unidadeConsumidoraService = unidadeConsumidoraService;
        }

        [HttpPost("CreateUnidadeConsumidora", Name = "CreateUnidadeConsumidora")]
        public IActionResult CreateUnidadeConsumidora([FromBody] UnidadeConsumidora unidadeConsumidora)
        {
            if (unidadeConsumidora == null)
            {
                return BadRequest("Unidade Consumidora inválido");
            }

            try
            {
                _unidadeConsumidoraService.Add(unidadeConsumidora);
                return CreatedAtRoute("GetByIdUnidadeConsumidora", new { id = unidadeConsumidora.Id }, unidadeConsumidora);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetByIdUnidadeConsumidora/{id}", Name = "GetByIdUnidadeConsumidora")]
        public IActionResult GetByIdUnidadeConsumidora(int id)
        {
            try
            {
                var unidadeConsumidora = _unidadeConsumidoraService.GetById(id);
                if (unidadeConsumidora == null)
                {
                    return NotFound();
                }
                return Ok(unidadeConsumidora);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("UpdateUnidadeConsumidora/{id}", Name = "UpdateUnidadeConsumidora")]
        public IActionResult UpdateUnidadeConsumidora(int id, [FromBody] UnidadeConsumidora unidadeConsumidora)
        {
            try
            {
                if (unidadeConsumidora == null || id != unidadeConsumidora.Id)
                {
                    return BadRequest("UnidadeConsumidora inválido");
                }

                _unidadeConsumidoraService.Update(unidadeConsumidora);

                return Ok(unidadeConsumidora);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteUnidadeConsumidora/{id}", Name = "DeleteUnidadeConsumidora")]
        public IActionResult DeleteUnidadeConsumidora(int id)
        {
            try
            {
                var unidadeConsumidora = _unidadeConsumidoraService.GetById(id);
                if (unidadeConsumidora == null)
                {
                    return NotFound();
                }

                _unidadeConsumidoraService.Delete(unidadeConsumidora);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
