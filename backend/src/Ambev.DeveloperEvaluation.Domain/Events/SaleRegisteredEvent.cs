using System;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleRegisteredEvent
    {
        public void SaleCreated(Guid saleId, Guid customerId, DateTime saleDate)
        {
            LogEvent("SaleCreated", $"Venda criada: ID = {saleId}, Cliente = {customerId}, Data = {saleDate}");
        }

        public void SaleModified(Guid saleId, DateTime modifiedDate)
        {
            LogEvent("SaleModified", $"Venda modificada: ID = {saleId}, Data de modificação = {modifiedDate}");
        }

        public void SaleCancelled(Guid saleId, DateTime cancellationDate)
        {
            LogEvent("SaleCancelled", $"Venda cancelada: ID = {saleId}, Data de cancelamento = {cancellationDate}");
        }

        public void ItemCancelled(Guid saleId, Guid itemId, DateTime cancellationDate)
        {
            LogEvent("ItemCancelled", $"Item cancelado: Venda ID = {saleId}, Item ID = {itemId}, Data de cancelamento = {cancellationDate}");
        }

        private void LogEvent(string eventType, string message)
        {
            Console.WriteLine($"[Evento: {eventType}] {message}");
        }
    }
}
