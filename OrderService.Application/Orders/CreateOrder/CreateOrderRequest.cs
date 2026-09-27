using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Application.Orders.CreateOrder
{
    

    public sealed class CreateOrderRequest
    {
        public Guid CustomerId { get; init; }
        public List<CreateOrderItemRequest> Items { get; init; } = [];
    }

    public sealed class CreateOrderItemRequest
    {
        public Guid ProductId { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
    }
}
