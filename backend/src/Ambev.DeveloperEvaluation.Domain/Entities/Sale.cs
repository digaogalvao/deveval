using System;
using System.Collections.Generic;
using System.Linq;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid BranchId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public SaleStatus Status { get; private set; }
        private readonly List<SaleItem> _items = new();
        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

        public Sale(DateTime saleDate, Guid customerId, Guid branchId)
        {
            Id = Guid.NewGuid(); // ID gerado automaticamente
            SaleNumber = GenerateSaleNumber();
            SaleDate = saleDate;
            CustomerId = customerId;
            BranchId = branchId;
            Status = SaleStatus.Pending;  // Status inicial
        }

        public void AddItem(SaleItem item)
        {
            if (Status == SaleStatus.Cancelled)
                throw new InvalidOperationException("Não é possível adicionar itens a uma venda cancelada.");

            var discountedItem = new SaleItem(item.ProductId, item.Quantity, item.UnitPrice);
            _items.Add(discountedItem);
            CalculateTotalAmount();
        }

        public void Cancel()
        {
            if (Status == SaleStatus.Completed)
                throw new InvalidOperationException("Não é possível cancelar uma venda já concluída.");

            Status = SaleStatus.Cancelled;
        }

        public void CompleteSale()
        {
            if (Status == SaleStatus.Cancelled)
                throw new InvalidOperationException("Não é possível concluir uma venda cancelada.");

            if (!_items.Any())
                throw new InvalidOperationException("Não é possível concluir uma venda sem itens.");

            Status = SaleStatus.Completed;
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = _items.Sum(item => item.TotalPrice);
        }

        private string GenerateSaleNumber()
        {
            return $"SALE-{DateTime.UtcNow:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
        }
    }
}
