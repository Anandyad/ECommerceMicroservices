using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Domain.Enum
{
    public enum OrderStatus
    {
        Pending = 1,
        InventoryReserved = 2,
        PaymentPending = 3,
        PaymentCompleted = 4,
        Confirmed = 5,
        InventoryFailed = 6,
        PaymentFailed = 7,
        Cancelled = 8
    }
}
