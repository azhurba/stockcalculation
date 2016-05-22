using StockProductivityCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockProductivityCalculation
{
    public static class StockCalculator
    {
        public static IList<decimal> Calculate(IStockData data)
        {
            var totalRecords = data.Years + 1;
            var result = new List<decimal>(totalRecords);
            result.Add(data.Price * data.Quantity);
            for (int i = 1; i < totalRecords; i++)
            {
                result.Add(result[i - 1]);
                result[i] += result[i] * (decimal)data.Percentage / 100;
            }
            return result;
        }
    }

    public interface IStockData
    {
        decimal Price { get; set; }
        int Quantity { get; set; }
        double Percentage { get; set; }
        int Years { get; set; }
    }

    public class StockData : IStockData
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Percentage { get; set; }
        public int Years { get; set; }

        public StockData(StockDetails details)
        {
            if (!details.Years.HasValue
                || !details.Quantity.HasValue
                || !details.Price.HasValue
                || !details.Percentage.HasValue)
            {
                throw new ArgumentException("details");
            }

            this.Percentage = details.Percentage.Value;
            this.Price = details.Price.Value;
            this.Quantity = details.Quantity.Value;
            this.Years = details.Years.Value;
        }

        public StockData() { }
    }
}