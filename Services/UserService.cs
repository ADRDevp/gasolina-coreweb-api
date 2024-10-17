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

    // Método para obtener todos los usuarios
    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // Método para obtener un usuario por ID
    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    // Método para crear un nuevo usuario
    public async Task CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    // Método para actualizar un usuario existente
    public async Task<bool> UpdateUser(int id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);

        if (existingUser == null)
        {
            return false; // No se encontró el usuario
        }

        // Actualizar propiedades del usuario
        existingUser.UserName = user.UserName;
        existingUser.Password = user.Password;
        existingUser.TypeUser = user.TypeUser;
        existingUser.Status = user.Status;

        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();
        return true;
    }

    // Método para eliminar un usuario por ID
    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false; // No se encontró el usuario
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
