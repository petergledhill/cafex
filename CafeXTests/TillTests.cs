using System;
using Xunit;
using CafeX;
using System.Collections.Generic;
using Xunit.Extensions;

namespace CafeXTests
{
    public class TillTests
    {   
        public static IEnumerable<object[]> CalculateBillData
        {
            get
            {
                return new[]
                {
                    // no items returns 0
                    new object[] { new List<string> { }, 0m },
                    // each item individually should return the price of that item
                    new object[] { new List<string> { "Cola" }, 0.5m },
                    new object[] { new List<string> { "Coffee" }, 1m },
                    new object[] { new List<string> { "Cheese Sandwich" }, 2m },
                    new object[] { new List<string> { "Steak Sandwich" }, 0.5m },      
                    // multiple items should return combined total
                    new object[] { new List<string> { "Cola", "Coffee", "Cheese Sandwich" }, 3.5m }                    
                };
            }
        }

        [Theory, MemberData("CalculateBillData")]
        public void CalculateBill(List<string> items, decimal expected)
        {
            var result = Till.CalculateBill(items);
            Assert.Equal(expected, result);
        }


    }
}
