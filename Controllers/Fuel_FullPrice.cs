using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FullPriceController : ControllerBase
{
    private readonly FuelAssignmentContext _context;

    public FullPriceController(FuelAssignmentContext context)
    {
        _context = context;
    }

    // GET: api/FullPrice
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fuel_FullPrice>>> GetFullPrices()
    {
        return await _context.FullPrices.ToListAsync();
    }

    // GET: api/FullPrice/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Fuel_FullPrice>> GetFullPrice(int id)
    {
        var fullPrice = await _context.FullPrices.FindAsync(id);

        if (fullPrice == null)
        {
            return NotFound();
        }

        return fullPrice;
    }

    // POST: api/FullPrice
    [HttpPost]
    public async Task<ActionResult<Fuel_FullPrice>> PostFullPrice(Fuel_FullPrice fullPrice)
    {
        _context.FullPrices.Add(fullPrice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFullPrice), new { id = fullPrice.RegisterId }, fullPrice);
    }

    // PUT: api/FullPrice/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFullPrice(int id, Fuel_FullPrice fullPrice)
    {
        if (id != fullPrice.RegisterId)
        {
            return BadRequest();
        }

        _context.Entry(fullPrice).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FullPriceExists(id))
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

    // DELETE: api/FullPrice/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFullPrice(int id)
    {
        var fullPrice = await _context.FullPrices.FindAsync(id);
        if (fullPrice == null)
        {
            return NotFound();
        }

        _context.FullPrices.Remove(fullPrice);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FullPriceExists(int id)
    {
        return _context.FullPrices.Any(e => e.RegisterId == id);
    }
}
