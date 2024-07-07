﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Features.Students.Command.Models;
using SchoolProjectCore.Features.AppUser.Command.Model;
using SchoolProjectCore.Resources;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.AppUser.Command.Validations
{
    public class AddUserValidation: AbstractValidator<AddUserCommand>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public AddUserValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
