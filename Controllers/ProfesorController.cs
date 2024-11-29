using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using APISystem.Entity;
using UniAPISystem.Models;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;
using Microsoft.AspNetCore.Authorization;

namespace UniAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpPost] //novi 
        public async Task<IActionResult> AddProfesorAsync([FromBody] ProfesorCreateDto profesorDto)
        {
            await _profesorService.AddProfesorAsync(profesorDto);
            return Ok("Profesor dodat uspesno!");
        }


        [HttpGet] //sve 
        public async Task<IActionResult> GetAllProfesoriAsync()
        {
            var profesor = await _profesorService.GetAllProfesoriAsync();
            return Ok(profesor);
        }


        [HttpGet("{id}")] //po ID
        public async Task<IActionResult> GetProfesorWithIdAsync([FromRoute] int id)
        {
            var profesor = await _profesorService.GetProfesorByIdAsync(id);

            if (profesor == null)
            {
                return NotFound($"Profesor sa ID {id} ne postoji.");
            }

            return Ok(profesor);
        }

        [HttpDelete("{id}")] //brise postojeci 
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var profesor = await _profesorService.GetProfesorByIdAsync(id);
            if (profesor == null)
            {
                return NotFound(new { Message = $"Profesor nije {id} nadjen." });
            }

            try
            {
                await _profesorService.DeleteProfesorAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }


            return Ok(new { Message = "Obrisano.", DeletedProfesorId = id });
        }
    }
}