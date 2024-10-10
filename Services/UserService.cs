using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

public class UserService
{
    private readonly FuelDBContext _context;

    public UserService(FuelDBContext context)
    {
        _context = context;
    }

    // SP para obtener la información de los usuarios
    public async Task<List<User>> GetInfoUser()
    {
        return await _context.Users
            .FromSqlRaw("EXEC dbo.sp_GetInfoUser")
            .ToListAsync();
    }
}
