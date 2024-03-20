using System;
namespace FeedExpenseCalculator.Service.Entities.FeedData
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public FoodType FoodType { get; set; }
        public decimal? PercentageOfMeat { get; set; }
    }
}
