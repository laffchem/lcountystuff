using Models;

namespace WorkOrderSystem.Core.Interfaces
{
    public interface ITechnicianRepository
    {
        Task<Technician> GetTechnicianByIdAsync(int id);

        Task<IReadOnlyList<Technician>> GetTechniciansAsync();
    }
}