using gasolina_asp.net_core_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly FuelDBContext _context;

    public CarsController(FuelDBContext context)
    {
        _context = context;
    }

    // GET: api/Cars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        return await _context.Cars.ToListAsync();
    }

    // GET: api/Cars/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        return car;
    }

    // POST: api/Cars
    [HttpPost]
    public async Task<ActionResult<Car>> PostCar(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCar), new { id = car.VehiclesId }, car);
    }

    // PUT: api/Cars/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, Car car)
    {
        if (id != car.VehiclesId)
        {
            return BadRequest();
        }

        _context.Entry(car).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CarExists(id))
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

    // DELETE: api/Cars/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.VehiclesId == id);
    }
}
