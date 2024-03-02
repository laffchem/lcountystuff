using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Technician
    {   
        [Key]
        public int TechnicianId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    
    }
}