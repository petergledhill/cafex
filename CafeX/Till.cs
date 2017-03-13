using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX
{
    public class Till
    {
        private static List<Product> Menu = new List<Product> {
            new Product( name : "Cola", cost : 0.5m ),
            new Product( name : "Coffee", cost : 1m ),
            new Product( name : "Cheese Sandwich", cost : 2m ),
            new Product( name : "Steak Sandwich", cost : 0.5m )
        };

        /// <summary>
        /// Calculate the total cost of the items provided
        /// </summary>                
        public static decimal CalculateBill(List<string> items)
        {
            var products = Menu.FindAll(p => items.Contains(p.Name));
            return products.Sum(p => p.Cost);            
        }
    }
}
