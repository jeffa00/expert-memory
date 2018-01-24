using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }

        // This was to answer Bill's question
        //public decimal Price { get; set; }
        //public decimal FoodCostPerMonth { get; set; }

        //public decimal WeightedCost
        //{
        //    get
        //    {
        //        return Price / 12 + FoodCostPerMonth;
        //    }
        //}
    }
}
