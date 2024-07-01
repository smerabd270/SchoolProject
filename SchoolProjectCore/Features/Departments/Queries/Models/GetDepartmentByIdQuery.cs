using MediatR;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.Departments.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery:IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
