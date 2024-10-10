using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // GET: api/Users/Info
    [HttpGet("Info")]
    public async Task<IActionResult> GetInfoUser()
    {
        var users = await _userService.GetInfoUser();
        return Ok(users);
    }
}
