using CogeconAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CogeconAPI.Interfaces;

namespace CogeconAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CooperadoController : ControllerBase
    {
        private readonly ICooperadoService _cooperadoService;

        public CooperadoController(ICooperadoService cooperadoService)
        {
            _cooperadoService = cooperadoService;
        }

        [HttpPost("CreateCooperado", Name = "CreateCooperado")]
        public IActionResult CreateCooperado([FromBody] Cooperado cooperado)
        {
            if (cooperado == null)
            {
                return BadRequest("Cooperado inválido");
            }

            try
            {
                _cooperadoService.Add(cooperado);
                return CreatedAtRoute("GetByIdCooperado", new { id = cooperado.Id }, cooperado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetByIdCooperado/{id}", Name = "GetByIdCooperado")]
        public IActionResult GetByIdCooperado(int id)
        {
            try
            {
                var cooperado = _cooperadoService.GetById(id);
                if (cooperado == null)
                {
                    return NotFound();
                }
                return Ok(cooperado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("UpdateCooperado/{id}", Name = "UpdateCooperado")]
        public IActionResult UpdateCooperado(int id, [FromBody] Cooperado cooperado)
        {
            try
            {
                if (cooperado == null || id != cooperado.Id)
                {
                    return BadRequest("Cooperado inválido");
                }

                _cooperadoService.Update(cooperado);

                return Ok(cooperado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteCooperado/{id}", Name = "DeleteCooperado")]
        public IActionResult DeleteCooperado(int id)
        {
            try
            {
                var cooperado = _cooperadoService.GetById(id);
                if (cooperado == null)
                {
                    return NotFound();
                }

                _cooperadoService.Delete(cooperado);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
