﻿using APISystem.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using UniAPISystem.Interface;

namespace UniAPISystem.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly UniverzitetContext _context;

        public ProfesorService()
        {
            _context = new UniverzitetContext();
        }


        public async Task<Profesor> GetProfesorByIdAsync(int id)
        {
           return await _context.Profesori.FindAsync(id);
        }

        public async Task AddProfesorAsync(Profesor profesor)
        {
            await _context.Profesori.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesorAsync(Profesor profesor)
        {
            _context.Profesori.Update(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesorAsync(int id)
        {
            var profesor = await GetProfesorByIdAsync(id);
            
            
                _context.Profesori.Remove(profesor);
                await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Profesor>> GetAllProfesoriAsync()
        {
            return await _context.Profesori.ToListAsync();
        }
    }
}