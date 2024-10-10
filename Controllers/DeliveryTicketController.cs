using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

[ApiController]
[Route("api/[controller]")]
public class DeliveryTicketController : ControllerBase
{
    private readonly FuelDBContext _context;

    public DeliveryTicketController(FuelDBContext context)
    {
        _context = context;
    }

    // GET: api/DeliveryTicket
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeliveryTicket>>> GetDeliveryTickets()
    {
        return await _context.DeliveryTickets.ToListAsync();
    }

    // GET: api/DeliveryTicket/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DeliveryTicket>> GetDeliveryTicket(int id)
    {
        var deliveryTicket = await _context.DeliveryTickets.FindAsync(id);

        if (deliveryTicket == null)
        {
            return NotFound();
        }

        return deliveryTicket;
    }

    // POST: api/DeliveryTicket
    [HttpPost]
    public async Task<ActionResult<DeliveryTicket>> PostDeliveryTicket(DeliveryTicket deliveryTicket)
    {
        _context.DeliveryTickets.Add(deliveryTicket);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDeliveryTicket), new { id = deliveryTicket.DeliveryId }, deliveryTicket);
    }

    // PUT: api/DeliveryTicket/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDeliveryTicket(int id, DeliveryTicket deliveryTicket)
    {
        if (id != deliveryTicket.DeliveryId)
        {
            return BadRequest();
        }

        _context.Entry(deliveryTicket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DeliveryTicketExists(id))
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

    // DELETE: api/DeliveryTicket/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDeliveryTicket(int id)
    {
        var deliveryTicket = await _context.DeliveryTickets.FindAsync(id);
        if (deliveryTicket == null)
        {
            return NotFound();
        }

        _context.DeliveryTickets.Remove(deliveryTicket);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DeliveryTicketExists(int id)
    {
        return _context.DeliveryTickets.Any(e => e.DeliveryId == id);
    }
}
