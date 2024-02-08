using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly OpeningTimeOption _option;
    public ProjectsController(IOptions<OpeningTimeOption> options)
    {
        _option = options.Value;
    }
    
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectModel createProjectModel)
    {
        if (createProjectModel.Title.Length > 50)
        {
            return BadRequest();
        }
        
        return CreatedAtAction(nameof(GetById), new {Id = createProjectModel.Id}, createProjectModel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProjectModel)
    {
        if (updateProjectModel.Description.Length > 200)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        return NoContent();
    }
    
    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentModel createCommentModel)
    {
        return NoContent();
    }
    
    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        return NoContent();
    }
}