using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FuelTicketsController : ControllerBase
{
    private readonly FuelAssignmentContext _context;

    public FuelTicketsController(FuelAssignmentContext context)
    {
        _context = context;
    }

    // GET: api/FuelTickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fuel_FuelTickets>>> GetFuelTickets()
    {
        return await _context.FuelTickets.ToListAsync();
    }

    // GET: api/FuelTickets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Fuel_FuelTickets>> GetFuelTicket(int id)
    {
        var fuelTicket = await _context.FuelTickets.FindAsync(id);

        if (fuelTicket == null)
        {
            return NotFound();
        }

        return fuelTicket;
    }

    // POST: api/FuelTickets
    [HttpPost]
    public async Task<ActionResult<Fuel_FuelTickets>> PostFuelTicket(Fuel_FuelTickets fuelTicket)
    {
        _context.FuelTickets.Add(fuelTicket);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFuelTicket), new { id = fuelTicket.FuelTicketId }, fuelTicket);
    }

    // PUT: api/FuelTickets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFuelTicket(int id, Fuel_FuelTickets fuelTicket)
    {
        if (id != fuelTicket.FuelTicketId)
        {
            return BadRequest();
        }

        _context.Entry(fuelTicket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FuelTicketExists(id))
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

    // DELETE: api/FuelTickets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuelTicket(int id)
    {
        var fuelTicket = await _context.FuelTickets.FindAsync(id);
        if (fuelTicket == null)
        {
            return NotFound();
        }

        _context.FuelTickets.Remove(fuelTicket);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FuelTicketExists(int id)
    {
        return _context.FuelTickets.Any(e => e.FuelTicketId == id);
    }
}
