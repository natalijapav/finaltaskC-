using APISystem.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAPISystem.Interface;


namespace UniAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UlogeController : ControllerBase
    {
       

        private readonly IUlogaService _ulogaService;

        public UlogeController(IUlogaService ulogaService)
        {
            _ulogaService = ulogaService;
        }

        // Dohvata sve uloge
        [HttpGet]
        public async Task<IActionResult> GetAllUlogeAsync()
        {
            var uloge = await _ulogaService.GetAllUlogeAsync();
            return Ok(uloge);
        }

        //Kreira novu ulogu
        [HttpPost]
        public async Task<IActionResult> AddUlogaAsync([FromBody] Uloga uloga)
        {
            if (uloga == null)
            {
                return BadRequest("Naziv uloge je obavezan.");
            }

            var newUloga = await _ulogaService.AddUlogaAsync(uloga);
            return CreatedAtAction(nameof(GetAllUlogeAsync), new { id = newUloga.UlogaId }, newUloga);
        }
    }
}
