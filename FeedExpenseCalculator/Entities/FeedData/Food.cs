using System;
namespace FeedExpenseCalculator.Service.Entities.FeedData
{
    public class Food
    {
        public FoodType FoodType { get; set; }
        public decimal Price { get; set; }
    }

    public enum FoodType
    {
        Fruit = 0,
        Meat = 1
    }
}
