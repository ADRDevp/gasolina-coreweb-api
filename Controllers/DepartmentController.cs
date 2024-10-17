using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: api/Departments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
    {
        var departments = await _departmentService.GetAllDepartments();
        return Ok(departments);
    }

    // GET: api/Departments/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartmentById(int id)
    {
        var department = await _departmentService.GetDepartmentById(id);

        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }
}
