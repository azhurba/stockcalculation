using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockProductivityCalculation.Models
{
    public class StockDetails
    {
        [Required]
        public string Name { get; set; }
        [Required]        
        public decimal? Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
        [Required]
        [Range(0, 100)]
        public double? Percentage { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? Years { get; set; }
    }
}