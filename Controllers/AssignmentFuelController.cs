using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AssignmentFuelController : ControllerBase
{
    private readonly FuelTicketService _fuelTicketService;

    public AssignmentFuelController(FuelTicketService fuelTicketService)
    {
        _fuelTicketService = fuelTicketService;
    }

    // GET: api/AssignmentFuel/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssignmentFuel(int id)
    {
        var assignmentFuel = await _fuelTicketService.GetAssignment(id);
        return assignmentFuel == null ? NotFound() : Ok(assignmentFuel);
    }
}
