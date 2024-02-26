using Microsoft.EntityFrameworkCore;
using WorkOrderSystem.Core.Interfaces;
using Models;

namespace WorkOrderSystem.Data
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkOrder> CreateWorkOrderAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();
            return workOrder;
        }

        public async Task<bool> DeleteWorkOrderAsync(int id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);

            if (workOrder == null)
            {
                return false; // Work order not found
            }

            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<WorkOrder> GetWorkOrderByIdAsync(int Id)
        {
            return await _context.WorkOrders
            .FindAsync(Id);
        }

        public async Task<IReadOnlyList<WorkOrder>> GetWorkOrdersAsync()
        {
            return await _context.WorkOrders
            .Include(w => w.Technician)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<WorkOrder>> GetWorkOrdersByStatusAsync(string status)
        {
            return await _context.WorkOrders
                .Where(w => w.Status == status)
                .Include(w => w.Technician)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<WorkOrder>> GetWorkOrdersByTechnicianIdAsync(int TechnicianId)
        {
            return await _context.WorkOrders
                .Where(w => w.TechnicianId == TechnicianId)
                .Include(w => w.Technician)
                .ToListAsync();
        }

        public async Task<bool> UpdateWorkOrderAsync(int id, WorkOrder updatedWorkOrder)
        {
            var existingWorkOrder = await _context.WorkOrders.FindAsync(id);

            if (existingWorkOrder == null)
            {
                return false; // Work order not found
            }

            // Update properties of existingWorkOrder with the values from updatedWorkOrder

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
