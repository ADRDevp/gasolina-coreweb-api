using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;


[ApiController]
[Route("api/[controller]")]
public class DetailTicketController : ControllerBase
{
    private readonly DetailTicketService _detailTicketService;

    public DetailTicketController(DetailTicketService detailTicketService)
    {
        _detailTicketService = detailTicketService;
    }

    // GET: api/DetailTicket
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetailTicket>>> GetAllDetailTickets()
    {
        var tickets = await _detailTicketService.GetAllDetailTickets();
        return Ok(tickets);
    }

    // GET: api/DetailTicket/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailTicket>> GetDetailTicketById(decimal id)
    {
        var ticket = await _detailTicketService.GetDetailTicketById(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    // POST: api/DetailTicket
    [HttpPost]
    public async Task<ActionResult<DetailTicket>> CreateDetailTicket(DetailTicket detailTicket)
    {
        await _detailTicketService.CreateDetailTicket(detailTicket);
        return CreatedAtAction(nameof(GetDetailTicketById), new { id = detailTicket.DetailId }, detailTicket);
    }

    // PUT: api/DetailTicket/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDetailTicket(decimal id, DetailTicket detailTicket)
    {
        if (id != detailTicket.DetailId)
        {
            return BadRequest();
        }

        var updated = await _detailTicketService.UpdateDetailTicket(id, detailTicket);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/DetailTicket/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDetailTicket(decimal id)
    {
        var deleted = await _detailTicketService.DeleteDetailTicket(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
