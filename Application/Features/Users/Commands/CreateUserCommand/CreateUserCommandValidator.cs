using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The {PropertyName} is required.");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The {PropertyName} is required.")
                .EmailAddress().WithMessage("The {PropertyName} must be a valid email address.");
            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("The {PropertyName} is required.");
            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("The {PropertyName} is required.");
        }
    }
}
