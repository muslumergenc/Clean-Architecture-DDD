namespace DDDTest.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        public Product(string name, decimal price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            if (price <= 0)
                throw new ArgumentException("Product price must be greater than zero.", nameof(price));

            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Product price must be greater than zero.", nameof(newPrice));

            Price = newPrice;
        }

        public void UpdateProductName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Product name cannot be empty.", nameof(newName));

            Name = newName;
        }
    }

}
