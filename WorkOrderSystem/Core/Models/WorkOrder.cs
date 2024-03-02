using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class WorkOrder

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactName { get; set;}
        [Required]
        public string ContactNumber { get; set; } = "1234567898";
        [Required]
        public string Problem { get; set; }

        public DateTime DateReceived { get; set; }

        public DateTime DateAssigned { get; set; }

        public DateTime? DateComplete { get; set; } = null;
        
        [Required]
        public string Status { get; set; }
        [Required]
        public int TechnicianId { get; set; } // FK Property
        [Required]
        public Technician Technician { get; set; } // Nav Property

        public WorkOrder()
        {
            DateAssigned = DateReceived;
        }
        
    }
}