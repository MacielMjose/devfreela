using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        
        if (user is null)
            return NotFound();
        
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewUserInputModel newUserInputModel)
    {
        var newUserId = _userService.Create(newUserInputModel);
        
        return CreatedAtAction(nameof(GetById), new { id = newUserId }, newUserInputModel);
    }

    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel loginModel)
    {
        return NoContent();
    }
}