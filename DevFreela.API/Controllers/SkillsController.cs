using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var skills = _skillService.GetAll();
        return Ok(skills);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var skill = _skillService.GetById(id);

        if (skill is null)
            return NotFound();
        
        return Ok(skill);
    }

    [HttpPost]
    public IActionResult Post()
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        return NoContent();
    }
}