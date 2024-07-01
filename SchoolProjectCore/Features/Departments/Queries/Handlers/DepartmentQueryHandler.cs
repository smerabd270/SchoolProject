using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.Departments.Queries.Models;
using SchoolProjectCore.Features.Departments.Queries.Response;
using SchoolProjectCore.Resources;
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
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
        }

        public Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
