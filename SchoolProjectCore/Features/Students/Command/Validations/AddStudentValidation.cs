using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolProjectCore.Features.Students.Command.Models;
using ShoolProjectService.Abstract;

namespace SchoolProjectCore.Features.Students.Command.Validations
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentValidation(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRule();
            ApplyCustomValidationRule();
        }

        
        public void ApplyValidationRule()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage("Name mus not be embty")
                .NotNull().WithMessage("Name mus not be null")
                .MaximumLength(30).WithMessage("Name max length is 30");
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage("Address mus not be embty")
               .NotNull().WithMessage("Address mus not be null")
               .MaximumLength(30).WithMessage("Address max length is 30");


        }
        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExit(Key)).WithMessage("Name Exit");
        }
    }
}
