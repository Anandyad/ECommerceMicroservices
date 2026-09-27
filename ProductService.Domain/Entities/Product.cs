using System.Xml.Linq;

namespace ProductService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public bool IsActive  { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public Product()
        {

        }
        public Product( string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.");

            if (price < 0)
                throw new ArgumentException("Product price cannot be negative.");
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            IsActive = true;
            CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}
