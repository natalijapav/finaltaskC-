using APISystem.Entity;
using APISystem.Entity;
using APSystem.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using UniAPISystem.Controllers;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class StudentService : IStudentService
    {
        private readonly UniverzitetContext _context;

        public StudentService()
        {
            _context = new UniverzitetContext();
        }


        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Studenti.FindAsync(id);
        }
        public async Task AddStudentAsync(Student student)
        {
            await _context.Studenti.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentAsync(StudentCreateDto studentDto)
        {
            var student = new Student
            {
                BrojIndeksa = studentDto.BrojIndeksa,
                NacinFinansiranja = studentDto.NacinFinansiranja,
            };

            await _context.Studenti.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Studenti.FindAsync(id);
            if (student != null)
            {
                _context.Osobe.Remove(student);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpisPredmet(int osobaId, int predmetId)
        {
            var osoba = await _context.Osobe.FindAsync(osobaId);
            if (osoba == null)
                throw new Exception("Osoba nije pronadjena.");
            if (osoba is Student student)
            {
                var predmet = await _context.Predmeti.FindAsync(predmetId);
                if (predmet == null)
                    throw new Exception("Predmet nije pronadjen.");

                if (!student.Predmeti.Contains(predmet))
                {
                    student.Predmeti.Add(predmet);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new Exception("Upis nije moguc.");
            }

        }

        public async Task<IEnumerable<Student>> GetAllStudentiAsync()
        {
            return await _context.Studenti.ToListAsync();
        }

        public Task GetStudentWithPredmetiAsync(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
