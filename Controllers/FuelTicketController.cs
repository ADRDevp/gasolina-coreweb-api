using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

[ApiController]
[Route("api/[controller]")]
public class FuelTicketController : ControllerBase
{
    private readonly FuelTicketService _fuelTicketService;

    public FuelTicketController(FuelTicketService fuelTicketService)
    {
        _fuelTicketService = fuelTicketService;
    }

    // GET: api/FuelTicket
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuelTicket>>> GetAllFuelTickets()
    {
        var tickets = await _fuelTicketService.GetAllFuelTickets();
        return Ok(tickets);
    }

    // GET: api/FuelTicket/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<FuelTicket>> GetFuelTicketById(decimal id)
    {
        var ticket = await _fuelTicketService.GetFuelTicketById(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    // POST: api/FuelTicket
    [HttpPost]
    public async Task<ActionResult<FuelTicket>> CreateFuelTicket(FuelTicket fuelTicket)
    {
        await _fuelTicketService.CreateFuelTicket(fuelTicket);
        return CreatedAtAction(nameof(GetFuelTicketById), new { id = fuelTicket.FuelTicketId }, fuelTicket);
    }

    // PUT: api/FuelTicket/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuelTicket(decimal id, FuelTicket fuelTicket)
    {
        if (id != fuelTicket.FuelTicketId)
        {
            return BadRequest();
        }

        var updated = await _fuelTicketService.UpdateFuelTicket(id, fuelTicket);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/FuelTicket/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuelTicket(decimal id)
    {
        var deleted = await _fuelTicketService.DeleteFuelTicket(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
