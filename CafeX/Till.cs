using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX
{
    public class Till
    {
        private static List<Product> Menu = new List<Product> {
            new Product( name : "Cola", cost : 0.5m, type : ProductType.Drink, isHot : false ),
            new Product( name : "Coffee", cost : 1m, type : ProductType.Drink, isHot : true ),
            new Product( name : "Cheese Sandwich", cost : 2m, type : ProductType.Food, isHot : false ),
            new Product( name : "Steak Sandwich", cost : 0.5m, type : ProductType.Food, isHot : true )
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
