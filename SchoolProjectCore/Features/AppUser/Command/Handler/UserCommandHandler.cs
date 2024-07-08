using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.AppUser.Command.Model;
using SchoolProjectCore.Resources;
using SchoolProjectData.Entities.Identity;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.AppUser.Command.Handler
{
    public class UserCommandHandler  : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
      private readonly UserManager<User> _userManager;
        public UserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
          _userManager = userManager;
        }


        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var CheckUserEmail = await _userManager.FindByEmailAsync(request.Email);
            if (CheckUserEmail != null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            }
            var CheckUserName = await _userManager.FindByNameAsync(request.UserName);
            if (CheckUserName != null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);

            }
    var newUser = _mapper.Map<User>(request);
    var createUser = await _userManager.CreateAsync(newUser);
            if (!createUser.Succeeded) 
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);

            }

return SuccessMessage<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }
    }
}
