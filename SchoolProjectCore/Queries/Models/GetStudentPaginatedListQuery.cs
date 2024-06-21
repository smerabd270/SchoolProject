using MediatR;
using SchoolProjectCore.Queries.Response;
using SchoolProjectCore.Warppers;
using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Queries.Models
{
    public class GetStudentPaginatedListQuery:IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ?[]OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
