using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;


[ApiController]
[Route("api/[controller]")]
public class DetailTicketController : ControllerBase
{
    private readonly FuelDBContext _context;

    public DetailTicketController(FuelDBContext context)
    {
        _context = context;
    }

    // PUT: api/DetailTicket/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDetailTicket(int id, DetailTicket detailTicket)
    {
        if (id != detailTicket.DetailId)
        {
            return BadRequest();
        }

        _context.Entry(detailTicket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DetailTicketExists(id))
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

    // DELETE: api/DetailTicket/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDetailTicket(int id)
    {
        var detailTicket = await _context.DetailTickets.FindAsync(id);
        if (detailTicket == null)
        {
            return NotFound();
        }

        _context.DetailTickets.Remove(detailTicket);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DetailTicketExists(int id)
    {
        return _context.DetailTickets.Any(e => e.DetailId == id);
    }
}
