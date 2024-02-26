namespace Models
{
    public class WorkOrder

    {
        public required int id { get; set; }
        public required string Email { get; set; }

        public required string ContactName { get; set;}
        public required string Problem { get; set; }

        public DateTime DateReceived { get; set; }
        public required string Status { get; set; }

        public int? TechnicianId { get; set; } // FK Property

        public Technician? Technician { get; set; } // Nav Property
        
    }
}