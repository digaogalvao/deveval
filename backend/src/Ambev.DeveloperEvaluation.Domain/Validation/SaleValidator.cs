using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.CustomerId)
                .NotEmpty().WithMessage("O cliente é obrigatório");

            RuleFor(sale => sale.BranchId)
                .NotEmpty().WithMessage("A filial é obrigatória");

            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("A data da venda é obrigatória")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data da venda não pode ser no futuro");

            RuleFor(sale => sale.TotalAmount)
                .GreaterThan(0).WithMessage("O valor total deve ser maior que zero");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("A venda deve conter pelo menos um item");

            RuleForEach(sale => sale.Items)
                .Must(item => item.Quantity <= 20)
                .WithMessage("Não pode haver mais de 20 itens por produto");

            RuleForEach(sale => sale.Items)
                .Must(item => item.Quantity >= 4 || item.DiscountAmount == 0)
                .WithMessage("Descontos não podem ser aplicados para menos de 4 itens");

            RuleForEach(sale => sale.Items)
                .Must(item => item.DiscountAmount >= 0)
                .WithMessage("O desconto não pode ser negativo");

            RuleFor(sale => sale.TotalAmount)
                .Equal(sale => sale.Items.Sum(item => item.TotalPrice))
                .WithMessage("O valor total deve ser a soma dos preços totais dos itens");

            RuleForEach(sale => sale.Items)
                .SetValidator(new SaleItemValidator());
        }
    }
}
