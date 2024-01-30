using System.ComponentModel.DataAnnotations;

namespace AdamsHospitalAPI.Models
{
    public class PrescApplication
    {
        [Key] 
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientAdress { get; set;}
        public string MedName { get; set; }
        public string Dosage { get; set; }
        public string DocName { get; set; }
        public string DocLNum { get; set; }
        public DateTime PrescDate { get; set; }
        public string DocNotes { get; set; } 
    }
}
