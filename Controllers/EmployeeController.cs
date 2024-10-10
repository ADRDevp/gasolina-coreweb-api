using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // POST: api/Employees
    [HttpPost]
    public async Task<IActionResult> SetEmployee(int employeeId, string employeeName)
    {
        await _employeeService.SetEmployee(employeeId, employeeName);
        return Ok();
    }
}
