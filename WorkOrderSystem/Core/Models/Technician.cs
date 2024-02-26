using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Technician
    {   
        [Key]
        public int TechnicianId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    
    }
}