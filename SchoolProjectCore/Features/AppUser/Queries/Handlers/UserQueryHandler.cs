using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.AppUser.Queries.Models;
using SchoolProjectCore.Features.AppUser.Queries.Response;
using SchoolProjectCore.Queries.Response;
using SchoolProjectCore.Resources;
using SchoolProjectCore.Warppers;
using SchoolProjectData.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.AppUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserListResponse>>
                                                   ,IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper = null, UserManager<User> userManager = null) : base(stringLocalizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<PaginatedResult<GetUserListResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users =  _userManager.Users.AsQueryable();
            var pageList =await  _mapper.ProjectTo<GetUserListResponse>(users).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            return pageList;
        }

        public async  Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x=> x.Id == request.Id);
            if (user == null)
                return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
    }

}
