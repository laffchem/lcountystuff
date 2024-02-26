using Models;

namespace WorkOrderSystem.Core.Interfaces
{
    public interface IWorkOrderRepository
    {
        Task<WorkOrder> GetWorkOrderByIdAsync(int id);
        Task<IReadOnlyList<WorkOrder>> GetWorkOrdersAsync();
        Task<IReadOnlyList<WorkOrder>> GetWorkOrdersByTechnicianIdAsync(int technicianId);
        Task<IReadOnlyList<WorkOrder>> GetWorkOrdersByStatusAsync(string status);

        Task<WorkOrder> CreateWorkOrderAsync(WorkOrder workOrder);
        Task<bool> UpdateWorkOrderAsync(int id, WorkOrder updatedWorkOrder);
        Task<bool> DeleteWorkOrderAsync(int id);
    }
}