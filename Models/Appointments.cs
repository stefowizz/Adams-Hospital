using System.ComponentModel.DataAnnotations;

namespace AdamsHospitalAPI.Models
{
    public class Appointments
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; } 
        public string Description { get; set; }
    }
}
