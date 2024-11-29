using APISystem.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using UniAPISystem.Interface;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.Models;
using Microsoft.AspNetCore.Authorization;




namespace UniAPISystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        private readonly UniverzitetContext _context; 

        public KorisnikController(UniverzitetContext context)
        {
            _context = context;
        }

       
        
        [HttpGet]
        public async Task<IActionResult> GetAllKorisniciAsync()
        {
            var korisnici = await _context.Korisnici
                    .Include(k => k.UlogaKorisnik) 
                    .ToListAsync();

            return Ok(korisnici);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKorisnikByIdAsync(int id)
        {
            var korisnik = await _context.Korisnici
                .Include(k => k.UlogaKorisnik)
                .FirstOrDefaultAsync(k => k.KorisnikId == id);

            if (korisnik == null) return NotFound();

            return Ok(korisnik);
        }

       
        [HttpPost]
        public async Task<IActionResult> AddKorisnikAsync([FromBody] Korisnik korisnik)
        {
            if (korisnik == null) return BadRequest("Nevalidan zahtev.");

            _context.Korisnici.Add(korisnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKorisnikByIdAsync), new { id = korisnik.KorisnikId }, korisnik);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisnikAsync(int id, [FromBody] Korisnik korisnik)
        {
            if (id != korisnik.KorisnikId) return BadRequest("ID se ne poklapa.");

            var existingKorisnik = await _context.Korisnici.FindAsync(id);
            if (existingKorisnik == null) return NotFound();

            existingKorisnik.KorisnickoIme = korisnik.KorisnickoIme;
            existingKorisnik.Lozinka = korisnik.Lozinka;
            existingKorisnik.UlogaId = korisnik.UlogaId;

            _context.Korisnici.Update(existingKorisnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnikAsync(int id)
        {
            var korisnik = await _context.Korisnici.FindAsync(id);
            if (korisnik == null) return NotFound();

            _context.Korisnici.Remove(korisnik);
            await _context.SaveChangesAsync();

            return Ok("Korisnik obrisan.");
        }


    }
}
