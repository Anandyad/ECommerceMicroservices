using OrderService.Domain.Entities;

namespace OrderService.Application.Orders.CreateOrder;

public class CreateOrderService
{
    public Order Create(CreateOrderRequest request)
    {
        var order = new Order(request.CustomerId);

        foreach (var item in request.Items)
        {
            order.AddItem(
                item.ProductId,
                item.ProductName,
                item.UnitPrice,
                item.Quantity);
        }

        return order;
    }
}