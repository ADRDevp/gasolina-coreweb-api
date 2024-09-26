using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    private readonly FuelAssignmentContext _context;

    public DriversController(FuelAssignmentContext context)
    {
        _context = context;
    }

    // GET: api/Drivers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fuel_Drivers>>> GetDrivers()
    {
        return await _context.Drivers.ToListAsync();
    }

    // GET: api/Drivers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Fuel_Drivers>> GetDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);

        if (driver == null)
        {
            return NotFound();
        }

        return driver;
    }

    // POST: api/Drivers
    [HttpPost]
    public async Task<ActionResult<Fuel_Drivers>> PostDriver(Fuel_Drivers driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDriver), new { id = driver.EmployeeNumber }, driver);
    }

    // PUT: api/Drivers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDriver(int id, Fuel_Drivers driver)
    {
        if (id != driver.EmployeeNumber)
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
        var driver = await _context.Drivers.FindAsync(id);
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
        return _context.Drivers.Any(e => e.EmployeeNumber == id);
    }
}
