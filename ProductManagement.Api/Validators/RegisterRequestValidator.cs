using FluentValidation;
using ProductManagement.Api.Model;

namespace ProductManagement.Api.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage($"Invalid First Name.");

            RuleFor(x => x.LastName)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage($"Invalid Last Name");

            RuleFor(x => x.Password)
                 .NotNull()
                 .NotEmpty()
                 .MinimumLength(6)
                 .WithMessage($"Password must have minimum 6 letters.");

            RuleFor(x => x.EmailAddress)
                 .NotNull()
                 .NotEmpty()
                 .EmailAddress()
                 .WithMessage($"Please enter valid email address.");
        }
    }
}
