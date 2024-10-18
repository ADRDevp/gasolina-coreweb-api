using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using gasolina_asp.net_core_web_api.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        await _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        var updated = await _userService.UpdateUser(id, user);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUser(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("ValidateUser")]
    public async Task<IActionResult> ValidateUser(string userName, string password)
    {
        bool isValid = await _userService.ValidateUser(userName, password);
        if (isValid)
        {
            return Ok("User is valid.");
        }
        return Unauthorized("Invalid credentials.");
    }
}
