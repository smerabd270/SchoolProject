using MediatR;
using SchoolProjectCore.Features.AppUser.Queries.Response;
using SchoolProjectCore.Warppers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.AppUser.Queries.Models
{
    public  class GetUserPaginationQuery:IRequest<PaginatedResult<GetUserListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
