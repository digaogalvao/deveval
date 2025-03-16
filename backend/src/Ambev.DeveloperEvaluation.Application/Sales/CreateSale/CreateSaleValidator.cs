using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.");

            RuleFor(x => x.SaleDate)
                .NotEmpty().WithMessage("A data da venda é obrigatória.")
                .Must(date => date <= DateTime.Now).WithMessage("A data da venda não pode ser no futuro.");

            RuleForEach(x => x.Items)
                .NotNull().WithMessage("Cada item deve ser válido.")
                .ChildRules(items =>
                {
                    items.RuleFor(x => x.ProductId).NotEmpty().WithMessage("O ID do produto é obrigatório.");
                    items.RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("A quantidade do item deve ser maior que zero.");
                    items.RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");
                });
        }
    }
}
