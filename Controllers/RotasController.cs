using MasterApi.Core.Interface.Services;
using MasterApi.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        private readonly IRotaService _rotaService;

        public RotasController(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        //GET: api/Rotas
        [HttpGet]
        public async Task<ActionResult> GetRotasAsync()
        {
            try
            {
                var _response = await _rotaService.GetAllAsync();
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Rotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRota(int id)
        {
            try
            {
                var _response = await _rotaService.GetAsync(id);

                if (_response == null)
                {
                    return NotFound();
                }

                return Ok(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ViagemMaisEconomica")]
        public async Task<ActionResult> Economica([FromBody] RotasDto rotas)
        {
            try
            {
                var _response = await _rotaService.CaminhoMaisEconomicoAsync(rotas);

                if (_response == null)
                {
                    return NotFound();
                }

                return Ok(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Rotas
        [HttpPost("AdicionarRota")]
        public async Task<ActionResult> PostRota([FromBody] RotaModel rota)
        {
            try
            {
                if (ModelState.IsValid)
                    await _rotaService.Add(rota);

                return Created("Rota criada!", rota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Rotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotaAsync(int id)
        {
            try
            {                
                await _rotaService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Rotas/5
        [HttpPut]
        public IActionResult PutRota(RotaModel rota)
        {
            try
            {
                _rotaService.Update(rota);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
