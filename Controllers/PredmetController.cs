
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APISystem.Entity;
using UniAPISystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace UniAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PredmetController : ControllerBase
    {
        private readonly UniverzitetContext _context;

        public PredmetController(UniverzitetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPredmeti()
        {
            var predmeti = await _context.Predmeti.ToListAsync();
            return Ok(predmeti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPredmetById(int id)
        {
            var predmet = await _context.Predmeti.FindAsync(id);

            if (predmet == null)
            {
                return NotFound(new { Message = $"Predmet sa ID {id} nije pronađen." });
            }

            return Ok(predmet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePredmet([FromBody] Predmet predmet)
        {
            if (predmet == null)
            {
                return BadRequest("Podaci su nevalidni.");
            }

            _context.Predmeti.Add(predmet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPredmetById), new { id = predmet.PredmetId }, predmet);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePredmet(int id, [FromBody] Predmet predmet)
        {
            if (id != predmet.PredmetId)
            {
                return BadRequest("ID predmeta ne odgovara.");
            }

            var postojeciPredmet = await _context.Predmeti.FindAsync(id);
            if (postojeciPredmet == null)
            {
                return NotFound(new { Message = $"Predmet sa ID {id} nije pronađen." });
            }

            postojeciPredmet.Naziv = predmet.Naziv;
            postojeciPredmet.ProfesorId = predmet.ProfesorId;
            postojeciPredmet.DepartmantId = predmet.DepartmantId;

            _context.Entry(postojeciPredmet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(postojeciPredmet);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredmet(int id)
        {
            var predmet = await _context.Predmeti.FindAsync(id);

            if (predmet == null)
            {
                return NotFound(new { Message = $"Predmet sa ID {id} nije pronađen." });
            }

            _context.Predmeti.Remove(predmet);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Predmet je uspešno obrisan.", DeletedPredmetId = id });
        }

     

            
            [HttpPost("{predmetId}/DodajProfesora/{profesorId}")]
            public async Task<IActionResult> DodajProfesora(int predmetId, int profesorId)
            {
                
                var predmet = await _context.Predmeti.FindAsync(predmetId);
                if (predmet == null)
                {
                    return NotFound($"Predmet sa ID {predmetId} nije pronađen.");
                }

                var profesor = await _context.Profesori.FindAsync(profesorId);
                if (profesor == null)
                {
                    return NotFound($"Profesor sa ID {profesorId} nije pronađen.");
                }

                
                if (predmet.ProfesorId.HasValue)
                {
                    return BadRequest($"Predmet {predmet.Naziv} već ima dodeljenog profesora.");
                }

                
                predmet.ProfesorId = profesorId;

                await _context.SaveChangesAsync();

                return Ok(new { Message = $"Profesor {profesor.OsobaIme} {profesor.OsobaPrezime} je uspešno dodeljen predmetu {predmet.Naziv}." });
            }
        }

    }







