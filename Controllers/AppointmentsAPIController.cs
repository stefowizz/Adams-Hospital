using AdamsHospitalAPI.Data;
using AdamsHospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdamsHospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsAPIController : ControllerBase
    {


        private readonly AdamsDbContext _dbContext;
        public AppointmentsAPIController(AdamsDbContext context)
        {
            _dbContext = context;
        }




        [HttpGet]
        public async Task<ActionResult<List<Appointments>>> GetAllAppointments()
        {
            var lstAppointments = await _dbContext.appointments.ToListAsync();
            return Ok(lstAppointments);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<Appointments>> GetAppointmentByID(int id)
        {
            var Appoint = await _dbContext.appointments.FindAsync(id);

            if(Appoint == null)
            {
                return BadRequest();
            }
            return Ok(Appoint); 
        }




        [HttpPost]
        public async Task<ActionResult<Appointments>> CreateAppointment(Appointments Appoint)
        {
            _dbContext.appointments.Add(Appoint);

            await _dbContext.SaveChangesAsync();

            return Ok(Appoint);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Appointments>> UpdateAppointment(Appointments Appoint)
        {
            if(Appoint == null)
            {
                return BadRequest();
            }
            _dbContext.appointments.Update(Appoint); 
            await _dbContext.SaveChangesAsync();
            return Ok(Appoint);
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointments>> DeleteAppointment(int id)
        {
            var Appoint = await _dbContext.appointments.FindAsync(id);
            if(Appoint == null)
            {
                return BadRequest();
            }
            _dbContext.appointments.Remove(Appoint);
            await _dbContext.SaveChangesAsync();
            return Ok(); 
        } 
    }
}
