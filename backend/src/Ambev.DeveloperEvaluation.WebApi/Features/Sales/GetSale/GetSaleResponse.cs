using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResponse
{
    public Guid SaleId { get; set; }
    public string SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleItemResponseDto> Items { get; set; } = new();
}

public class SaleItemResponseDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}