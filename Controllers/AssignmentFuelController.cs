using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AssignmentFuelController : ControllerBase
{
    private readonly FuelAssignmentContext _context;

    public AssignmentFuelController(FuelAssignmentContext context)
    {
        _context = context;
    }

    // GET: api/AssignmentFuel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentFuels>>> GetAssignmentFuels()
    {
        return await _context.AssignmentFuels.ToListAsync();  // Cambiado a AssignmentFuels
    }

    // GET: api/AssignmentFuel/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentFuels>> GetAssignmentFuel(int id)
    {
        var assignmentFuel = await _context.AssignmentFuels.FindAsync(id);  // Cambiado a AssignmentFuels

        if (assignmentFuel == null)
        {
            return NotFound();
        }

        return assignmentFuel;
    }

    // POST: api/AssignmentFuel
    [HttpPost]
    public async Task<ActionResult<AssignmentFuels>> PostAssignmentFuel(AssignmentFuels assignmentFuel)
    {
        _context.AssignmentFuels.Add(assignmentFuel);  // Cambiado a AssignmentFuels
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAssignmentFuel), new { id = assignmentFuel.AssignmentFuelId }, assignmentFuel);
    }

    // PUT: api/AssignmentFuel/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAssignmentFuel(int id, AssignmentFuels assignmentFuel)
    {
        if (id != assignmentFuel.AssignmentFuelId)
        {
            return BadRequest();
        }

        _context.Entry(assignmentFuel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AssignmentFuelExists(id))
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

    // DELETE: api/AssignmentFuel/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignmentFuel(int id)
    {
        var assignmentFuel = await _context.AssignmentFuels.FindAsync(id);  // Cambiado a AssignmentFuels
        if (assignmentFuel == null)
        {
            return NotFound();
        }

        _context.AssignmentFuels.Remove(assignmentFuel);  // Cambiado a AssignmentFuels
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AssignmentFuelExists(int id)
    {
        return _context.AssignmentFuels.Any(e => e.AssignmentFuelId == id);  // Cambiado a AssignmentFuels
    }
}
