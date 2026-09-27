using OrderService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Domain.Entities
{
    public sealed class Order
    {
        private readonly List<OrderItem> _items = new();
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public OrderStatus Status { get; private set; }

        public decimal TotalAmount { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        public int Version { get; private set; }
       // public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public Order(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("CustomerId is required.");

            Id = Guid.NewGuid();
            CustomerId = customerId;
            Status = OrderStatus.Pending;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
            Version = 1;
        }
        public void AddItem(Guid productId, string productName,decimal unitPrice,int quantity)
        {
            var item = new OrderItem( productId, productName,unitPrice,quantity);

            _items.Add(item);

            RecalculateTotal();

            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            Version++;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        private void RecalculateTotal()
        {
            TotalAmount = _items.Sum(x => x.TotalPrice);
        }
    }
}
