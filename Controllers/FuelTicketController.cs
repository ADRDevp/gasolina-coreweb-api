using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class FuelTicketController : ControllerBase
{
    private readonly FuelTicketService _fuelTicketService;

    public FuelTicketController(FuelTicketService fuelTicketService)
    {
        _fuelTicketService = fuelTicketService;
    }

    // GET: api/FuelTickets
    [HttpGet]
    public async Task<IActionResult> GetAllFuelTickets()
    {
        var tickets = await _fuelTicketService.GetAllFuelTickets();
        return Ok(tickets);
    }

    // POST: api/FuelTickets
    [HttpPost]
    public async Task<IActionResult> SetFuelTicket(int ticketId, string someField, string otherField)
    {
        await _fuelTicketService.SetFuelTicket(ticketId, someField, otherField);
        return Ok();
    }
}
