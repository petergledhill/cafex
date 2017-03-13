using System;
using Xunit;
using CafeX;

namespace CafeXTests
{
    public class TillTests
    {
        [Fact]
        public void CalculateBillReturns0IfNoItems()
        {
            var result = Till.CalculateBill();
            Assert.Equal(0, result);
        }
    }
}
