using System.Xml.Linq;

namespace OrderService.Domain.Entities
{
    public sealed class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantitiy { get; set; }

        public decimal TotalPrice => UnitPrice * Quantitiy;

        private OrderItem() { 
        
        }

        public OrderItem( Guid productId, string productName,  decimal unitprice ,int quantity ,int quantitiy = 0)
        {

            if (productId == Guid.Empty)
            {
                throw new ArgumentException("ProductId is required.");
            }
            if (String.IsNullOrWhiteSpace(productName ) ) 
            { 
              throw new ArgumentException("Product name is required");
            }
            if (unitprice < 0)
                throw new ArgumentException("Unit price cannot be negative.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");
        
        Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitprice;
            
        }
    }
}
