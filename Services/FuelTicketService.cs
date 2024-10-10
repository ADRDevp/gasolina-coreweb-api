using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

public class FuelTicketService
{
    private readonly FuelDBContext _context;

    public FuelTicketService(FuelDBContext context)
    {
        _context = context;
    }

    // SP para obtener todos los FuelTickets
    public async Task<List<FuelTicket>> GetAllFuelTickets()
    {
        return await _context.FuelTickets
            .FromSqlRaw("EXEC dbo.sp_GetAllFuelTicket")
            .ToListAsync();
    }

    // SP para obtener una asignación por ID
    public async Task<AssignmentFuel?> GetAssignment(int id)
    {
        var assignmentFuel = await _context.AssignmentFuels
            .FromSqlRaw("EXEC dbo.sp_GetAssignment @p0", id)
            .FirstOrDefaultAsync();

        if (assignmentFuel == null)
        {
            // Manejar el caso donde no se encuentra la asignación
            return null;  // Puedes manejar este caso como prefieras
        }

        return assignmentFuel;
    }

    // SP para insertar o actualizar un FuelTicket
    public async Task SetFuelTicket(int ticketId, string someField, string otherField)
    {
        await _context.Database.ExecuteSqlRawAsync(
            "EXEC dbo.sp_SetFuelTicket @p0, @p1, @p2", 
            ticketId, someField, otherField);
    }
}
