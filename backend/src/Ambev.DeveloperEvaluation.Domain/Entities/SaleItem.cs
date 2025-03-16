using System;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public decimal DiscountAmount => (UnitPrice * Quantity) * DiscountPercentage;
        public decimal TotalPrice => (UnitPrice * Quantity) - DiscountAmount;

        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid(); // ID gerado automaticamente
            ValidateQuantity(quantity);

            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            DiscountPercentage = CalculateDiscount(quantity);
        }

        public SaleItem(Guid productId, int quantity, decimal unitPrice, decimal discountPercentage)
        {
            Id = Guid.NewGuid();
            ValidateQuantity(quantity);

            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            DiscountPercentage = discountPercentage;
        }

        public void UpdateQuantity(int newQuantity)
        {
            ValidateQuantity(newQuantity);
            Quantity = newQuantity;
            DiscountPercentage = CalculateDiscount(newQuantity);
        }

        private void ValidateQuantity(int quantity)
        {
            if (quantity > 20)
                throw new ArgumentException("Não é possível vender mais de 20 itens idênticos.");
            if (quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        private decimal CalculateDiscount(int quantity)
        {
            return quantity switch
            {
                >= 10 and <= 20 => 0.20m,
                >= 4 and < 10 => 0.10m,
                _ => 0m
            };
        }

        public void ApplyDiscount(decimal discountRate)
        {
            DiscountPercentage = discountRate;
        }
    }
}
