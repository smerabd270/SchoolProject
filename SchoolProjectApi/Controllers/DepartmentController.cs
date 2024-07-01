using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjectCore.Features.Departments.Queries.Models;
using SchoolProjectCore.Queries.Models;
using SchoolProjectData.AppMetaData;

namespace SchoolProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(response);

        }
    }
}
