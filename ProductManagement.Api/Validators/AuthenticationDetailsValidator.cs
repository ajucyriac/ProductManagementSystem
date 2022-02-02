using FluentValidation;
using ProductManagement.Api.Model;

namespace ProductManagement.Api.Validators
{
    public class AuthenticationDetailsValidator : AbstractValidator<AuthenticationDetails>
    {

        public AuthenticationDetailsValidator()
        {
            RuleFor(x => x.Password)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage($"Password required.");

            RuleFor(x => x.EmailAddress)
                     .NotNull()
                     .NotEmpty()
                     .EmailAddress()
                     .WithMessage($"EmailAddress required.");
        }
        
    }
}
