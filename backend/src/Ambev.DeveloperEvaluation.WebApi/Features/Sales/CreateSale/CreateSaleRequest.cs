using System;
using System.Collections.Generic;

public class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleItemRequestDto> Items { get; set; } = new();
}

public class SaleItemRequestDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}