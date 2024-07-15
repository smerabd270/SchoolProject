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
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<EditUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>

    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationUserService _applicationUserService;
        public UserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager, IApplicationUserService applicationUserService = null) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _applicationUserService = applicationUserService;
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
            //   var createUser = await _applicationUserService.AddUserAsync(newUser, request.Password);
            var createUser = await _userManager.CreateAsync(newUser, request.Password);
            //switch (createUser)
            //{
            //    case "EmailIsExist": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            //    case "UserNameIsExist": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            //    case "ErrorInCreateUser": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            //    case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            //    case "Success": return Success<string>("");
            //    default: return BadRequest<string>(createUser);
            //}
            return Success<string>("");
        }
        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
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

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<string>();
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success((string)_stringLocalizer[SharedResourcesKeys.Success]);
        }
    }
}
