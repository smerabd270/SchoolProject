using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjectCore.Features.AppUser.Command.Model;
using SchoolProjectCore.Features.AppUser.Queries.Models;
using SchoolProjectCore.Features.Students.Command.Models;
using SchoolProjectCore.Queries.Models;
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
        [HttpGet(Router.UserRouting.PagenatedList)]
        public async Task<IActionResult> PagenatedList([FromQuery] GetUserPaginationQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);

        }
        [HttpGet(Router.UserRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(response);

        }
        [HttpPut(Router.UserRouting.Update)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut(Router.UserRouting.ChangePassword)]

        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
