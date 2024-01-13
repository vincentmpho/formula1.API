using formula1.API.Data;
using formula1.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace formula1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public DriversController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Drivers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);

                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, AddDriver);
            
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}
