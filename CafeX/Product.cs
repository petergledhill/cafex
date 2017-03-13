
namespace CafeX
{
    public class Product
    {
        public string Name { get; }
        public decimal Cost { get; }
        public ProductType Type { get; }
        public bool IsHot { get; }

        public Product(string name, decimal cost, ProductType type, bool isHot)
        {
            Name = name;
            Cost = cost;
            Type = type;
            IsHot = isHot;
        }
    }
}

