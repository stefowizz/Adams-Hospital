using AdamsHospitalAPI.Data;
using AdamsHospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdamsHospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMedHxAPIController : ControllerBase
    {




        private readonly AdamsDbContext _db;
        public PatientMedHxAPIController(AdamsDbContext db)
        {
            _db = db;
        }





        [HttpGet]
        public async Task<ActionResult<List<PatientMedHx>>> GetAllPatMedHx() 
        {
            var lstPatMedHx = await _db.Patients.ToListAsync();

            return Ok(lstPatMedHx); 
        } 




        [HttpGet("{id}")]
        public async Task<ActionResult<PatientMedHx>> GetPatMedHxById(int id)
        {
            var MedHx = await _db.Patients.FindAsync(id);

            if(MedHx == null)
            {
                return BadRequest();
            }

            return Ok(MedHx); 
        }





        [HttpPost]
        public async Task<ActionResult<PatientMedHx>> CreateMedHx(PatientMedHx MedHx)
        {
            _db.Patients.Add(MedHx);

            await _db.SaveChangesAsync();
            
            return Ok(MedHx);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<PatientMedHx>> UpdateMedHx(PatientMedHx MedHx)
        {
            if(MedHx == null)
            {
                return BadRequest();
            }

            _db.Patients.Update(MedHx);

            await _db.SaveChangesAsync();
            
            return Ok(MedHx);
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientMedHx>> DeleteMedHx(int id)
        {
            var MedHx = await _db.Patients.FindAsync(id);

            if( MedHx == null)
            {
                return BadRequest();
            }
            
            _db.Patients.Remove(MedHx);

            await _db.SaveChangesAsync();

            return Ok(); 
        }
    }
}
