
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;
using UniAPISystem.Models;

namespace Departmants.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]

public class DepartmantController : ControllerBase
{
    private readonly IDepartmantService _departmanService;
    private readonly UniverzitetContext _context;
    
    
    public DepartmantController(UniverzitetContext context)
    {
        _context = context;
    }

    [HttpGet("secure-endpoint")]
    public IActionResult SecureEndpoint()
    {
        return Ok("This is a secure endpoint.");
    }

    [HttpGet("another-secure-endpoint")]
    public IActionResult AnotherSecureEndpoint()
    {
        return Ok("This is another secure endpoint.");
    }

    [HttpPost] //dodaje novi departman
    public async Task<IActionResult> AddDepartmantAsync([FromBody] DepartmantCreateDto departmantDto)
    {
        await _departmanService.AddDepartmantAsync(departmantDto);
        return Ok("Departmant dodat uspesno!");
    }


    [HttpGet] //dohvata sve departmane
    public async Task<IActionResult> GetAllDepartmaniAsync()
    {
        var departmani = await _departmanService.GetAllDepartmantiAsync();
        return Ok(departmani);
    }


    [HttpGet("{id}")] //dohvata departmane po ID
    public async Task<IActionResult> GetDepartmanWithIdAsync([FromRoute] int id)
    {
        var departman = await _departmanService.GetDepartmantByIdAsync(id);

        if (departman == null)
        {
            return NotFound($"Departman sa ID {id} ne postoji.");
        }

        return Ok(departman);
    }


    

    [HttpPut("{id}")] //azurira postojeci departman
    public async Task<IActionResult> UpdateDepartman(int id, [FromBody] DepartmantUpdateDto departmantDto)
    {
        if (departmantDto == null)
        {
            return BadRequest(new { Message = "Podaci nisu validni." });
        }

        var departman = await _departmanService.GetDepartmantByIdAsync(id);
        if (departman == null)
        {
            return NotFound(new { Message = "Departman ne postoji." });
        }

        departman.DepartmantIme = departmantDto.DepartmantIme;
        departman.DepartmantId = departmantDto.DepartmantId;

        try
        {
            await _departmanService.UpdateDepartmantAsync(departman);

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Greska. Pokusaj ponovo." });

        }

        return Ok(new { Message = "Departman uspesno apdejtovan :D.", UpdatedDepartman = departman });
    }

    [HttpDelete("{id}")] //brise postojeci departman
    public async Task<IActionResult> DeleteDepartman(int id)
    {
        var departman = await _departmanService.GetDepartmantByIdAsync(id);
        if (departman == null)
        {
            return NotFound(new { Message = $"Departman nije {id} nadjen." });
        }

        try
        {
            await _departmanService.DeleteDepartmantAsync(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }


        return Ok(new { Message = "Departman obrisan.", DeletedDepartmanId = id });
    }

    [HttpPost("{departmanId}/DodajPredmet/{predmetId}")] //dodaje predmet na depart
    public async Task<IActionResult> DodajPredmetNaDepartman(int departmanId, int predmetId)
    {
        // Pronađi departman
        var departman = await _context.Departmanti
            .Include(d => d.Predmeti) 
            .FirstOrDefaultAsync(d => d.DepartmantId == departmanId);

        if (departman == null)
        {
            return NotFound($"Departman sa ID {departmanId} nije pronađen.");
        }

        //pronadji predmet
        var predmet = await _context.Predmeti.FindAsync(predmetId);
        if (predmet == null)
        {
            return NotFound("Predmet sa ID  nije pronađen.");
        }

        if (predmet.DepartmantId == departmanId)
        {
            return BadRequest("Predmet već pripada departmanu.");
        }

        // dodaj 
        predmet.DepartmantId = departmanId;
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Predmet uspešno dodeljen departmanu." });
    }


}


