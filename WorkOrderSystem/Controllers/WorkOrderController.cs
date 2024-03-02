using Microsoft.AspNetCore.Mvc;
using WorkOrderSystem.Core.Interfaces;
using WorkOrderSystem.Data.Dtos;
using Models;


namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrdersController(IWorkOrderRepository workOrderRepository) : ControllerBase
    {

        private readonly IWorkOrderRepository _workOrderRepository = workOrderRepository;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<WorkOrder>>> GetWorkOrders()
        {
            var workOrders = await _workOrderRepository.GetWorkOrdersAsync();
            return Ok(workOrders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkOrder>> GetWorkOrderByIdAsync(int id)
        {
            return Ok(await _workOrderRepository.GetWorkOrderByIdAsync(id));
        }

        [HttpGet("technician/{id}")]
        public async Task<ActionResult<IReadOnlyList<WorkOrder>>> GetWorkOrdersByTechnicianId(int id)
        {
            var workOrders = await _workOrderRepository.GetWorkOrdersByTechnicianIdAsync(id);

            if (workOrders == null || workOrders.Count == 0)
            {
                return NotFound();
            }

            return Ok(workOrders);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IReadOnlyList<WorkOrder>>> GetWorkOrdersByStatus(string status)
        {
            var workOrders = await _workOrderRepository.GetWorkOrdersByStatusAsync(status);
            if (workOrders == null || workOrders.Count == 0)
            {
                return NotFound();
            }
            return Ok(workOrders);
        }
        
        [HttpPost]
        public async Task<ActionResult<WorkOrder>> CreateWorkOrder(WorkOrderDto workOrderDto)
        {


            var createdWorkOrder = await _workOrderRepository.CreateWorkOrderAsync(workOrderDto);

            return Ok(createdWorkOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkOrder(int id, WorkOrder updatedWorkOrder)
        {
            var result = await _workOrderRepository.UpdateWorkOrderAsync(id, updatedWorkOrder);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOrder(int id)
        {
            var result = await _workOrderRepository.DeleteWorkOrderAsync(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
}

}