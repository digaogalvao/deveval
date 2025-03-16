using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductCommand>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID must not be empty.")
                .NotEqual(Guid.Empty).WithMessage("Product ID must be a valid GUID.");
        }
    }
}
