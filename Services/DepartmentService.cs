using gasolina_asp.net_core_web_api.Data;
using gasolina_asp.net_core_web_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DepartmentService
{
    private readonly FuelDBContext _context;

    public DepartmentService(FuelDBContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllDepartments()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department> GetDepartmentById(int id)
    {
        return await _context.Departments.FindAsync(id);
    }
}
