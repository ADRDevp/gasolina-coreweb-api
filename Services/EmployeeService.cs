using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

public class EmployeeService
{
    private readonly FuelDBContext _context;

    public EmployeeService(FuelDBContext context)
    {
        _context = context;
    }

    // SP para insertar o actualizar empleados
    public async Task SetEmployee(int employeeId, string employeeName)
    {
        await _context.Database.ExecuteSqlRawAsync(
            "EXEC dbo.sp_SetEmployees @p0, @p1", 
            employeeId, employeeName);
    }
}
