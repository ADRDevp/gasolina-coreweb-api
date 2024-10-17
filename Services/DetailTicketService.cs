using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using gasolina_asp.net_core_web_api.Data;

public class DetailTicketService
{
    private readonly FuelDBContext _context;

    public DetailTicketService(FuelDBContext context)
    {
        _context = context;
    }

    public async Task<List<DetailTicket>> GetAllDetailTickets()
    {
        return await _context.DetailTickets.ToListAsync();
    }

    public async Task<DetailTicket?> GetDetailTicketById(decimal id)
    {
        return await _context.DetailTickets.FindAsync(id);
    }

    public async Task CreateDetailTicket(DetailTicket detailTicket)
    {
        _context.DetailTickets.Add(detailTicket);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateDetailTicket(decimal id, DetailTicket detailTicket)
    {
        var existingTicket = await _context.DetailTickets.FindAsync(id);
        if (existingTicket == null)
        {
            return false;
        }

        _context.Entry(existingTicket).CurrentValues.SetValues(detailTicket);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDetailTicket(decimal id)
    {
        var ticket = await _context.DetailTickets.FindAsync(id);
        if (ticket == null)
        {
            return false;
        }

        _context.DetailTickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return true;
    }
}
