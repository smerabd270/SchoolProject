using FluentValidation;
using SchoolProjectCore.Features.Students.Command.Models;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Students.Command.Validations
{
    public class UpdateStudentValidation : AbstractValidator<UpdateStudentCommand>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentValidation(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRule();
            ApplyCustomValidationRule();
        }


        public void ApplyValidationRule()
        {
            RuleFor(x => x.Name)
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
            //    RuleFor(x => x.Name)
            //        .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExit(Key)).WithMessage("Name Exit");
        }
    }
}
