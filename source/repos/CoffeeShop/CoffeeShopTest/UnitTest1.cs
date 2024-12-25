using CoffeeShop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoffeeShopTest
{
    [TestClass]
    public class UnitTest1
    {
        Menu m1 = new CoffeeShop.Menu();

        [DataTestMethod]
        [DataRow(3.0, 3.0, true, true, 6.0)]
        [DataRow(3.0, 3.0, true, false, 3.0)]
        [DataRow(4.5, 3.0, true, false, 4.5)]
        [DataRow(4.5, 3.0, true, true, 7.5)]
        public void TestCalculation(double coffeePrice, double sandwichPrice, 
            bool isSandwichIncluded, bool isCoffeeIncluded, double expectedValue)
        {
            m1.UpdateMenu(coffeePrice, sandwichPrice);

            var order = new CoffeeShop.Order(m1);
            double actualTotal = 0;

            if (isCoffeeIncluded)
                actualTotal += coffeePrice;

            if (isSandwichIncluded)
                actualTotal += sandwichPrice;

            Assert.AreEqual(expectedValue, actualTotal);
        }
    }
}
