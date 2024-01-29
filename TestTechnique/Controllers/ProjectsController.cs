using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTechnique.Handler;
using TestTechnique.Models.DTO;

namespace TestTechnique.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private IMediator _mediator;
    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProjectDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListProject(CancellationToken cancellationToken)
    {
        var request = await _mediator.Send(new GetProjectList.Request(), cancellationToken).ConfigureAwait(false);
        if (request is null)
        {
            return BadRequest();
        }
        return Ok(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public async Task<IActionResult> NewProject([FromBody] NewProject.Request request, CancellationToken cancellationToken)
    {
        var req = _mediator.Send(request, cancellationToken);
        return Ok();
    }
}
