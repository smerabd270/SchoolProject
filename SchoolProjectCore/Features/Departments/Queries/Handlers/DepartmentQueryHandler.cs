using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.Departments.Queries.Models;
using SchoolProjectCore.Features.Departments.Queries.Response;
using SchoolProjectCore.Queries.Response;
using SchoolProjectCore.Resources;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
            IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;

        private IDepartmentService _departmentService;
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService, IMapper mapper) : base(stringLocalizer)
        {
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetById(request.Id);
            if(response == null) 
            {
                return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var result = _mapper.Map<GetDepartmentByIdResponse>(response);
            return Success(result);
        }
    }
}
