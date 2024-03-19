using CogeconAPI.Interfaces;
using CogeconAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CogeconAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost("CreateEndereco", Name = "CreateEndereco")]
        public IActionResult CreateEndereco([FromBody] Endereco endereco)
        {
            if (endereco == null)
            {
                return BadRequest("Endereco inválido");
            }

            try
            {
                _enderecoService.Add(endereco);
                return CreatedAtRoute("GetByIdEndereco", new { id = endereco.Id }, endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetByIdEndereco/{id}", Name = "GetByIdEndereco")]
        public IActionResult GetByIdEndereco(int id)
        {
            try
            {
                var Endereco = _enderecoService.GetById(id);
                if (Endereco == null)
                {
                    return NotFound();
                }
                return Ok(Endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("UpdateEndereco/{id}", Name = "UpdateEndereco")]
        public IActionResult UpdateEndereco(int id, [FromBody] Endereco Endereco)
        {
            try
            {
                if (Endereco == null || id != Endereco.Id)
                {
                    return BadRequest("Endereco inválido");
                }

                _enderecoService.Update(Endereco);

                return Ok(Endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteEndereco/{id}", Name = "DeleteEndereco")]
        public IActionResult DeleteEndereco(int id)
        {
            try
            {
                var Endereco = _enderecoService.GetById(id);
                if (Endereco == null)
                {
                    return NotFound();
                }

                _enderecoService.Delete(Endereco);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
