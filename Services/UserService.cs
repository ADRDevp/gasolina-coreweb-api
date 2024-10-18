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

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateUser(int id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);

        if (existingUser == null)
        {
            return false; 
        }

        existingUser.UserName = user.UserName;
        existingUser.Password = user.Password;
        existingUser.TypeUser = user.TypeUser;
        existingUser.Status = user.Status;

        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ValidateUser(string userName, string password)
    {
        var result = await _context.Users
            .FromSqlRaw("EXEC dbo.sp_ValidUser @UserName = {0}, @Password = {1}", userName, password)
            .ToListAsync();

        return result.Count > 0;
    }
}
