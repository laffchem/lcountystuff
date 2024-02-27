using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Models;
using WorkOrderSystem.Core.Interfaces;

namespace WorkOrderSystem.Data
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnicianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Technician> GetTechnicianByIdAsync(int id)
        {
            return await _context.Technicians.FindAsync(id);
            
        }

        public async Task<IReadOnlyList<Technician>> GetTechniciansAsync()
        {
            return await _context.Technicians
            .ToListAsync();
        }
    }
}