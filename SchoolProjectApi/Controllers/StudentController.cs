using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjectCore.Features.Students.Command.Models;
using SchoolProjectCore.Queries.Models;
using SchoolProjectData.AppMetaData;

namespace SchoolProjectApi.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult>GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
            
        }
        [HttpGet(Router.StudentRouting.PagenatedList)]
        public async Task<IActionResult> PagenatedList( [FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);

        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);

        }
        [HttpPost(Router.StudentRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [HttpPut(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delelte([FromBody] DeleteStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
