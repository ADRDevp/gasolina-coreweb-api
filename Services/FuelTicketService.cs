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

    public async Task<List<FuelTicket>> GetAllFuelTickets()
    {
        return await _context.FuelTickets.ToListAsync();
    }

    public async Task<FuelTicket?> GetFuelTicketById(decimal id)
    {
        return await _context.FuelTickets.FindAsync(id);
    }

    public async Task CreateFuelTicket(FuelTicket fuelTicket)
    {
        _context.FuelTickets.Add(fuelTicket);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateFuelTicket(decimal id, FuelTicket fuelTicket)
    {
        var existingTicket = await _context.FuelTickets.FindAsync(id);
        if (existingTicket == null)
        {
            return false;
        }

        _context.Entry(existingTicket).CurrentValues.SetValues(fuelTicket);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteFuelTicket(decimal id)
    {
        var ticket = await _context.FuelTickets.FindAsync(id);
        if (ticket == null)
        {
            return false;
        }

        _context.FuelTickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return true;
    }
}
