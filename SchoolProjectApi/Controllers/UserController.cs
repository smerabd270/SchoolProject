using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjectCore.Features.AppUser.Command.Model;
using SchoolProjectCore.Features.Students.Command.Models;
using SchoolProjectData.AppMetaData;

namespace SchoolProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Router.UserRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
