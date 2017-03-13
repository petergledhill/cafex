using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX
{
    public static class Till
    {
        private static decimal FOOD_SERVICE_CHARGE = 0.1m;
        private static decimal HOT_FOOD_SERVICE_CHARGE = 0.2m;
        private static decimal MAXIMUM_SERVICE_CHARGE = 20m;

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

        /// <summary>
        /// Given the total provided, calculate service charge for the given order type
        /// </summary>
        /// <returns>The total charge for service</returns>
        public static decimal ServiceCharge(decimal total, OrderType orderType)
        {
            var multiplier = 0m;

            if (orderType == OrderType.ContainsHotFood)
            {
                multiplier = HOT_FOOD_SERVICE_CHARGE;
            }

            if (orderType == OrderType.ContainsFood)
            {
                multiplier = FOOD_SERVICE_CHARGE;
            }

            var charge = Math.Round(total * multiplier, 2);
            return Math.Min(charge, MAXIMUM_SERVICE_CHARGE);
        }
    }
}
