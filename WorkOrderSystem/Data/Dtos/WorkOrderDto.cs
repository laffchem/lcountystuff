using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WorkOrderSystem.Data.Dtos
{
    public class WorkOrderDto
    {
    public string Email { get; set; }
    public string ContactName { get; set; }
    public string ContactNumber { get; set; }
    public string Problem { get; set; }
    public DateTime DateReceived { get; set; }
    public DateTime DateAssigned { get; set; }
    public DateTime? DateComplete { get; set; }   
    public string Status { get; set; }
    public int TechnicianId { get; set; }

    public WorkOrderDto()
    {
    }

    // Constructor that takes a WorkOrder object
    public WorkOrderDto(WorkOrder workOrder)
    {
        Email = workOrder.Email;
        ContactName = workOrder.ContactName;
        ContactNumber = workOrder.ContactNumber;
        Problem = workOrder.Problem;
        DateReceived = workOrder.DateReceived;
        DateAssigned = workOrder.DateAssigned;
        DateComplete = workOrder.DateComplete;
        Status = workOrder.Status;
        TechnicianId = workOrder.TechnicianId;
    }
    }

    
}