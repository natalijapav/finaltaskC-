using APISystem.Entity;
using APSystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class PredmetService : IPredmetService
    {
        private readonly UniverzitetContext _context;
        private Predmet predmet;

        public PredmetService()
        {
            _context = new UniverzitetContext();
        }


        public async Task<Predmet> GetPredmetByIdAsync(int id)
        {
            return await _context.Predmeti.FindAsync(id);
        }

        public async Task AddPredmetAsync(Predmet predmet)
        {
            await _context.Predmeti.AddAsync(predmet);
            await _context.SaveChangesAsync();
        }

        public async Task AddPredmetAsync(PredmetCreateDto predmetDto)
        {
            var predmet = new Predmet
            {

                PredmetId = predmetDto.PredmetId,
                Naziv = predmetDto.Naziv
            };

            await _context.Predmeti.AddAsync(predmet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePredmetAsync(Predmet predmet)
        {
            _context.Predmeti.Update(predmet);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePredmetAsync(int id)
        {
            var predmet = await GetPredmetByIdAsync(id);


            _context.Predmeti.Remove(predmet);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Predmet>> GetAllPredmetiAsync()
        {
            return await _context.Predmeti.ToListAsync();
        }
    }
}
