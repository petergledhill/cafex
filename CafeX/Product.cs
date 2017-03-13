
namespace CafeX
{
    public class Product
    {
        public string Name { get; }
        public decimal Cost { get; }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}

