using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockProductivityCalculation.Models;

namespace StockProductivityCalculation.Tests
{
    [TestClass]
    public class StockCalculatorTest
    {
        [TestMethod]
        public void TestCalculateYears0()
        {
            var data = new StockData
            {
                Price = 200,
                Percentage = 3,
                Quantity = 17,
                Years = 0
            };
            var result = StockCalculator.Calculate(data);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void TestCalculatePriceOrQuantity0()
        {
            var data = new StockData
            {
                Price = 0,
                Percentage = 3,
                Quantity = 17,
                Years = 7
            };
            var result = StockCalculator.Calculate(data);
            CheckValues(data, result);
            data.Price = 200;
            data.Quantity = 0;
            result = StockCalculator.Calculate(data);
            CheckValues(data, result);
        }

        private static void CheckValues(StockData data, System.Collections.Generic.IList<decimal> result)
        {
            Assert.AreEqual(data.Years + 1, result.Count);
            foreach (var value in result)
            {
                Assert.AreEqual(0, value);
            }
        }

        [TestMethod]
        public void TestCalculatePercentage0()
        {
            var data = new StockData
            {
                Price = 0,
                Percentage = 3,
                Quantity = 17,
                Years = 7
            };
            var result = StockCalculator.Calculate(data);
            Assert.AreEqual(data.Years + 1, result.Count);
            foreach (var value in result)
            {
                Assert.AreEqual(result[0], value);
            }
        }

        [TestMethod]
        //TODO: there are missed tests for double convertion to decimal
        public void TestCalculateByPriceMaxValue()
        {
            var data = new StockData
            {
                Price = decimal.MaxValue,
                Percentage = 3,
                Quantity = 17,
                Years = 6
            };

            try
            {
                StockCalculator.Calculate(data);
                Assert.Fail("An exception with OverflowException type is ecpexted.");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(OverflowException));
            }
        }

        [TestMethod]
        public void TestCalculateByRegularWay()
        {
            var data = new StockData
            {
                Price = 200,
                Percentage = 3,
                Quantity = 17,
                Years = 6
            };

            var result = StockCalculator.Calculate(data);

            Assert.AreEqual(data.Years + 1, result.Count);
            Assert.AreEqual(data.Price * data.Quantity, result[0]);
            for (int i = 1; i < result.Count; i++)
            {
                Assert.AreEqual(result[i - 1] + result[i - 1] * (decimal)data.Percentage / 100, result[i]); 
            }
        }
    }
}
