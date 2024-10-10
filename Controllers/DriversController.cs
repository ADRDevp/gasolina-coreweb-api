using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;


[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly FuelDBContext _context;

    public DriversController(FuelDBContext context)
    {
        _context = context;
    }

    // GET: api/Drivers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
    {
        return await _context.Drivers.ToListAsync();
    }

    // GET: api/Drivers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id.ToString());

        if (driver == null)
        {
            return NotFound();
        }

        return driver;
    }

    // POST: api/Drivers
    [HttpPost]
    public async Task<ActionResult<Driver>> PostDriver(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDriver), new { id = driver.Identification }, driver);
    }

    // PUT: api/Drivers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDriver(int id, Driver driver)
    {
        if (id.ToString() != driver.Identification)
        {
            return BadRequest();
        }

        _context.Entry(driver).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DriverExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Drivers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id.ToString());
        if (driver == null)
        {
            return NotFound();
        }

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DriverExists(int id)
    {
        return _context.Drivers.Any(e => e.Identification == id.ToString());
    }
}
