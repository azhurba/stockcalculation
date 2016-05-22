using StockProductivityCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockProductivityCalculation
{
    /// <summary>
    /// Class that keep information about Stock details from user and calculation results from system
    /// </summary>
    public class StockCalculationResult
    {
        public StockDetails Details { get; private set; }
        public IList<decimal> CalculationResults { get; private set; }

        public StockCalculationResult(StockDetails details, IList<decimal> results)
        {
            this.Details = details;
            this.CalculationResults = results;
        }
    }
}