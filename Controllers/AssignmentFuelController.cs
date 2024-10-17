using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Models;

[ApiController]
[Route("api/[controller]")]
public class AssignmentFuelController : ControllerBase
{
    private readonly AssignmentFuelService _assignmentFuelService;

    public AssignmentFuelController(AssignmentFuelService assignmentFuelService)
    {
        _assignmentFuelService = assignmentFuelService;
    }

    // GET: api/AssignmentFuel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentFuel>>> GetAllAssignments()
    {
        var assignments = await _assignmentFuelService.GetAllAssignments();
        return Ok(assignments);
    }

    // GET: api/AssignmentFuel/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentFuel>> GetAssignmentById(int id)
    {
        var assignment = await _assignmentFuelService.GetAssignmentById(id);
        if (assignment == null)
        {
            return NotFound();
        }
        return Ok(assignment);
    }

    // POST: api/AssignmentFuel
    [HttpPost]
    public async Task<IActionResult> CreateAssignment(AssignmentFuel assignmentFuel)
    {
        await _assignmentFuelService.CreateAssignment(assignmentFuel);
        return CreatedAtAction(nameof(GetAssignmentById), new { id = assignmentFuel.AssignmentFuelId }, assignmentFuel);
    }

    // PUT: api/AssignmentFuel/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAssignment(int id, AssignmentFuel assignmentFuel)
    {
        if (id != assignmentFuel.AssignmentFuelId)
        {
            return BadRequest();
        }

        var updated = await _assignmentFuelService.UpdateAssignment(id, assignmentFuel);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/AssignmentFuel/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(int id)
    {
        var deleted = await _assignmentFuelService.DeleteAssignment(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
