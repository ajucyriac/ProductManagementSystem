using FluentValidation;
using ProductManagement.Api.Model;

namespace ProductManagement.Api.Validators
{
    public class ProductDetailsValidator : AbstractValidator<ProductDetails>
    {
        public ProductDetailsValidator()
        {   
            RuleFor(x => x.ProductCode)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage($"Mininum 3 character required.");
            
            RuleFor(x => x.ProductName)
                .NotNull()
                .NotEmpty()
                .WithMessage($"Product Name required.");

            RuleFor(x => x.Quantity)
                .NotNull()
                .GreaterThan(0)
                .WithMessage($"Mininum one item is required.");

            RuleFor(x => x.UnitPrice)
                .NotNull()
                .GreaterThan(0)
                .WithMessage($"Unit Price should be greater than zero.");
            
            RuleFor(x => x.PackedDate)
                .NotNull()
                .WithMessage($"Packed date should not be null.");
            
            RuleFor(x => x.ExpiryDate)
                .NotNull()
                .GreaterThanOrEqualTo(x => x.PackedDate)
                .WithMessage($"Expiry Date should be greater than or equal to Packed Date.");
            
        }
    }
}
