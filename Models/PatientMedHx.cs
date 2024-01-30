using System.ComponentModel.DataAnnotations;

namespace AdamsHospitalAPI.Models
{
    public class PatientMedHx
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime VisitDate { get; set; }
        public string ChiefComplaint { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string DoctorsNotes { get; set; } 
    }
}
