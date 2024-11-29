
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;
using UniAPISystem.Models;

namespace UniAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        
        private UniverzitetContext _context;

       public StudentController(UniverzitetContext context)
        {
            _context = context;
        }

        [HttpPost] //novi 
        public async Task<IActionResult> AddStudentAsync([FromBody] StudentCreateDto studentDto)
        {
            await _studentService.AddStudentAsync(studentDto);
            return Ok("Student dodat uspesno!");
        }


        [HttpGet] //sve 
        public async Task<IActionResult> GetAllStudentiAsync()
        {
            var studenti = await _studentService.GetAllStudentiAsync();
            return Ok(studenti);
        }


        [HttpGet("{id}")] //po ID
        public async Task<IActionResult> GetStudentWithIdAsync([FromRoute] int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound($"Student sa ID {id} ne postoji.");
            }

            return Ok(student);
        }

        [HttpDelete("{id}")] //brise 
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound(new { Message = $"student nije {id} nadjen." });
            }

            try
            {
                await _studentService.DeleteStudentAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }


            return Ok(new { Message = "Obrisano.", DeletedStudentId = id });
        }


        [HttpPost("{studentId}/UpisiNaPredmet/{predmetId}")]
        public async Task<IActionResult> UpisiNaPredmet(int studentId, int predmetId)
        {
            // Pretraga studenta
            var student = await _context.Studenti.
                Include(s => s.Predmeti)
               .FirstOrDefaultAsync(s => s.OsobaId == studentId);
            if (student == null)
            {
                return NotFound($"Student sa ID {studentId} nije pronađen.");
            }

            // Pretraga predmeta
            var predmet = await _context.Predmeti.FindAsync(predmetId);
            if (predmet == null)
            {
                return NotFound($"Predmet sa ID {predmetId} nije pronađen.");
            }

            // Proveriti da li je student već upisan na predmet
            if (student.Predmeti.Contains(predmet))
            {
                return BadRequest($"Student je već upisan.");
            }

            // Dodavanje predmeta studentu
            student.Predmeti.Add(predmet);

            // Spremanje promena
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Student je uspešno upisan." });
        }






    }
}
