
using Microsoft.AspNetCore.Mvc;
using Models;
using WorkOrderSystem.Core.Interfaces;

namespace WorkOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicianController(ITechnicianRepository technicianRepository) : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository = technicianRepository;
    
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Technician>>> GetTechnicians()
        {
            var technicians = await _technicianRepository.GetTechniciansAsync();
            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Technician>> GetTechnicianByIdAsync(int id)
        {
            return Ok(await _technicianRepository.GetTechnicianByIdAsync(id));
        }

    }


}