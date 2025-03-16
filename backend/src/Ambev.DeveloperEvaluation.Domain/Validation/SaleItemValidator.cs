using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("O ID do produto é obrigatório");

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero");

            RuleFor(item => item.TotalPrice)
                .GreaterThanOrEqualTo(0).WithMessage("O preço total não pode ser negativo");

            RuleFor(item => item.Quantity)
                .LessThanOrEqualTo(20).WithMessage("Não pode haver mais de 20 itens por produto");

            RuleFor(item => item.DiscountAmount)
                .GreaterThanOrEqualTo(0).WithMessage("O desconto deve ser não negativo");
        }
    }
}
