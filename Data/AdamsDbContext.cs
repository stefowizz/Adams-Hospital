using AdamsHospitalAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdamsHospitalAPI.Data
{
    public class AdamsDbContext: IdentityDbContext
    {
        public AdamsDbContext(DbContextOptions<AdamsDbContext> options): base(options)
        {
            
        }
        public DbSet<Appointments> appointments { get; set; }
        public DbSet<PatientMedHx> Patients { get; set; }
        public DbSet<PrescApplication> PrescApplications { get; set; } 

    }
}
