using AdamsHospitalAPI.Data;
using AdamsHospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdamsHospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescAppAPIController : ControllerBase
    {


        private readonly AdamsDbContext _addiContext;
        public PrescAppAPIController(AdamsDbContext adamsDbContext)
        {
            _addiContext = adamsDbContext;
        }




        [HttpGet]
        public async Task<ActionResult<List<PrescApplication>>> GetAllApps()
        {
            var lstPApps = await _addiContext.PrescApplications.ToListAsync();

            return Ok(lstPApps);
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<PrescApplication>> GetAppById(int id)
        {
            var PApp = await _addiContext.PrescApplications.FindAsync(id);

            if (PApp == null)
            {
                return BadRequest();
            }
            return Ok(PApp);
        }





        [HttpPost]
        public async Task<ActionResult<PrescApplication>> CreateApp(PrescApplication PApp)
        {
            _addiContext.PrescApplications.Add(PApp);

            await _addiContext.SaveChangesAsync();

            return Ok(PApp);
        }






        [HttpPut("{id}")]
        public async Task<ActionResult<PrescApplication>> UpdateApp(PrescApplication PApp)
        {
            if (PApp == null)
            {
                return BadRequest();
            }

            _addiContext.PrescApplications.Update(PApp);

            await _addiContext.SaveChangesAsync();

            return Ok(PApp);
        }





        [HttpDelete("{id}")]
        public async Task<ActionResult<PrescApplication>> DeleteApp(int id)
        {
            var PApp = await _addiContext.PrescApplications.FindAsync(id);

            if (PApp == null)
            {
                return BadRequest();
            }

            _addiContext.PrescApplications.Remove(PApp);

            await _addiContext.SaveChangesAsync();

            return Ok();
        }
    }

}