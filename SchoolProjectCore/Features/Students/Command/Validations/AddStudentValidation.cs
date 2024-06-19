using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProjectCore.Features.Students.Command.Models;

namespace SchoolProjectCore.Features.Students.Command.Validations
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidation()
        {

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
    }
}
