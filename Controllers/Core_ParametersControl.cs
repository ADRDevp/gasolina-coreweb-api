using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ParametersControlController : ControllerBase
{
    private readonly FuelAssignmentContext _context;

    public ParametersControlController(FuelAssignmentContext context)
    {
        _context = context;
    }

    // GET: api/ParametersControl
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Core_ParametersControl>>> GetParametersControl()
    {
        return await _context.ParametersControl.ToListAsync();
    }

    // GET: api/ParametersControl/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Core_ParametersControl>> GetParameterControl(int id)
    {
        var parameterControl = await _context.ParametersControl.FindAsync(id);

        if (parameterControl == null)
        {
            return NotFound();
        }

        return parameterControl;
    }

    // POST: api/ParametersControl
    [HttpPost]
    public async Task<ActionResult<Core_ParametersControl>> PostParameterControl(Core_ParametersControl parameterControl)
    {
        _context.ParametersControl.Add(parameterControl);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetParameterControl), new { id = parameterControl.ParameterId }, parameterControl);
    }

    // PUT: api/ParametersControl/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutParameterControl(int id, Core_ParametersControl parameterControl)
    {
        if (id != parameterControl.ParameterId)
        {
            return BadRequest();
        }

        _context.Entry(parameterControl).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParameterControlExists(id))
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

    // DELETE: api/ParametersControl/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParameterControl(int id)
    {
        var parameterControl = await _context.ParametersControl.FindAsync(id);
        if (parameterControl == null)
        {
            return NotFound();
        }

        _context.ParametersControl.Remove(parameterControl);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ParameterControlExists(int id)
    {
        return _context.ParametersControl.Any(e => e.ParameterId == id);
    }
}
