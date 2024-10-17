using gasolina_asp.net_core_web_api.Data;
using gasolina_asp.net_core_web_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AssignmentFuelService
{
    private readonly FuelDBContext _context;

    public AssignmentFuelService(FuelDBContext context)
    {
        _context = context;
    }

    // Método para obtener todas las asignaciones de combustible
    public async Task<List<AssignmentFuel>> GetAllAssignments()
    {
        return await _context.AssignmentFuels.ToListAsync();
    }

    // Método para obtener una asignación de combustible por ID
    public async Task<AssignmentFuel> GetAssignmentById(int id)
    {
        return await _context.AssignmentFuels.FindAsync(id);
    }

    // Método para crear una nueva asignación de combustible
    public async Task CreateAssignment(AssignmentFuel assignmentFuel)
    {
        _context.AssignmentFuels.Add(assignmentFuel);
        await _context.SaveChangesAsync();
    }

    // Método para actualizar una asignación de combustible existente
    public async Task<bool> UpdateAssignment(int id, AssignmentFuel assignmentFuel)
    {
        var existingAssignment = await _context.AssignmentFuels.FindAsync(id);

        if (existingAssignment == null)
        {
            return false; // No se encontró la asignación
        }

        // Actualizar propiedades de la asignación
        existingAssignment.EmployeeNumber = assignmentFuel.EmployeeNumber;
        existingAssignment.Identification = assignmentFuel.Identification;
        existingAssignment.FullName = assignmentFuel.FullName;
        existingAssignment.Positions = assignmentFuel.Positions;
        existingAssignment.Amount = assignmentFuel.Amount;
        existingAssignment.Status = assignmentFuel.Status;
        existingAssignment.VehicleId = assignmentFuel.VehicleId;
        existingAssignment.DriverType = assignmentFuel.DriverType;
        existingAssignment.DepartmentId = assignmentFuel.DepartmentId;

        _context.AssignmentFuels.Update(existingAssignment);
        await _context.SaveChangesAsync();
        return true;
    }

    // Método para eliminar una asignación de combustible por ID
    public async Task<bool> DeleteAssignment(int id)
    {
        var assignmentFuel = await _context.AssignmentFuels.FindAsync(id);
        if (assignmentFuel == null)
        {
            return false; // No se encontró la asignación
        }

        _context.AssignmentFuels.Remove(assignmentFuel);
        await _context.SaveChangesAsync();
        return true;
    }
}
