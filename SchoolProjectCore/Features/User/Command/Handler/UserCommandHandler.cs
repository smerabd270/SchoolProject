using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.User.Command.Model;
using SchoolProjectCore.Resources;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.User.Command.Handler
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public UserCommandHandler( IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        public Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
