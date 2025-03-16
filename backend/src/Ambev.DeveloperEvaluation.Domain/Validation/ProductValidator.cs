using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty).WithMessage("Product ID must be a valid GUID.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Product title is required.")
                .MaximumLength(100).WithMessage("Product title must be less than 100 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Product description is required.")
                .MaximumLength(500).WithMessage("Product description must be less than 500 characters.");

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Product category is required.");

            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("Product image URL is required.")
                .Matches(@"^https?://").WithMessage("Product image must be a valid URL.");

            RuleFor(p => p.Rating)
                .IsInEnum().WithMessage("Product rating must be a valid rating value (1-5).")
                .NotNull().WithMessage("Product rating must be provided.");
        }
    }
}
