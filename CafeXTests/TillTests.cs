using System;
using Xunit;
using CafeX;
using System.Collections.Generic;

namespace CafeXTests
{
    public class TillTests
    {

        #region CalculateBill

        public static IEnumerable<object[]> CalculateBillData
        {
            get
            {
                return new[]
                {
                    // no items returns 0
                    new object[] { new List<string> { }, 0m },
                    // each item individually should return the price of that item inc service charge
                    new object[] { new List<string> { "Cola" }, 0.5m },
                    new object[] { new List<string> { "Coffee" }, 1m },
                    new object[] { new List<string> { "Cheese Sandwich" }, 2.2m },
                    new object[] { new List<string> { "Steak Sandwich" }, 5.4m },      
                    // multiple items should return combined total inc service charge
                    new object[] { new List<string> { "Cola", "Coffee", "Cheese Sandwich" }, 3.85m },
                    new object[] { new List<string> { "Cola", "Coffee", "Cheese Sandwich", "Steak Sandwich" }, 9.6 }
                };
            }
        }
        
        // Theory to test each of the senarios outlined in CalculateBillData
        [Theory, MemberData("CalculateBillData")]
        public void CalculateBill(List<string> items, decimal expected)
        {
            var result = Till.CalculateBill(items);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateBill_ShouldHandleDuplicatesCorrectly()
        {
            var items = new List<string> { "Cheese Sandwich", "Cheese Sandwich" };
            var result = Till.CalculateBill(items);
            Assert.Equal(4.4m, result);
        }

        [Fact]
        public void CalculateBill_ShouldHandleNullItemsCorrectly()
        {
            var items = new List<string> { "No Item" };
            var exception = Record.Exception(() => Till.CalculateBill(items));
            Assert.NotNull(exception);
            Assert.IsType<NullReferenceException>(exception);
        }

        #endregion

        #region ServiceCharge

        [Fact]
        public void ServiceCharge_Returns0Percent_AllDrinks()
        {
            var serviceCharge = Till.ServiceCharge(total: 10m, orderType : OrderType.AllDrinks);
            Assert.Equal(0, serviceCharge);
        }

        [Fact]
        public void ServiceCharge_Returns10Percent_Food()
        {
            var serviceCharge = Till.ServiceCharge(total: 10m, orderType: OrderType.ContainsFood);
            Assert.Equal(1m, serviceCharge);
        }

        [Fact]
        public void ServiceCharge_Returns20Percent_HotFood()
        {
            var serviceCharge = Till.ServiceCharge(total: 10m, orderType: OrderType.ContainsHotFood);
            Assert.Equal(2m, serviceCharge);
        }

        [Fact]
        public void ServiceCharge_RoundsTo2Places()
        {
            var serviceCharge = Till.ServiceCharge(total: 0.99m, orderType: OrderType.ContainsHotFood);
            Assert.Equal(0.2m, serviceCharge);
        }

        [Fact]
        public void ServiceCharge_ReturnsMaximum20PoundCharge()
        {
            var serviceCharge = Till.ServiceCharge(total: 400m, orderType: OrderType.ContainsHotFood);
            Assert.Equal(20m, serviceCharge);
        }

        #endregion

        #region GetOrderType

        [Fact]
        public void GetOrderType_Returns_AllDrinks_IfAllDrinks()
        {
            var products = new List<Product>()
            {
                new Product(name : "Drink1", cost : 0, type : ProductType.Drink, isHot : false)
            };
            var orderType = Till.GetOrderType(products);
            Assert.Equal(OrderType.AllDrinks, orderType);
        }

        [Fact]
        public void GetOrderType_Returns_ContainsFood_IfAnyFood()
        {
            var products = new List<Product>()
            {
                new Product(name : "Drink1", cost : 0, type : ProductType.Drink, isHot : false),
                new Product(name : "Cold Food1", cost : 0, type : ProductType.Food, isHot : false)
            };
            var orderType = Till.GetOrderType(products);
            Assert.Equal(OrderType.ContainsFood, orderType);
        }

        [Fact]
        public void GetOrderType_Returns_ContainsHotFood_IfAnyHotFood()
        {
            var products = new List<Product>()
            {
                new Product(name : "Cold Food1", cost : 0, type : ProductType.Food, isHot : false),
                new Product(name : "Hot Food1", cost : 0, type : ProductType.Food, isHot : true)
            };
            var orderType = Till.GetOrderType(products);
            Assert.Equal(OrderType.ContainsHotFood, orderType);
        }

        #endregion

    }
}
