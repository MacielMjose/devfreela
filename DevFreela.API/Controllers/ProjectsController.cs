using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _projectService.GetAll(query);
        
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);

        if (project is null)
            return NotFound();
        
        return  Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel newProjectInputModel)
    {
        if (newProjectInputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = _projectService.Create(newProjectInputModel);
        
        return CreatedAtAction(nameof(GetById), 
            new { Id = id }, 
            newProjectInputModel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdatProjectInputModel updatProjectInputModel)
    {
        if (updatProjectInputModel.Description.Length > 200)
        {
            return BadRequest();
        }
        
        _projectService.Update(updatProjectInputModel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _projectService.Delete(id);
        
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createCommentInputModel)
    {
        _projectService.CreateComment(createCommentInputModel);
        
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _projectService.Start(id);
        
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _projectService.Finish(id);
        
        return NoContent();
    }
}