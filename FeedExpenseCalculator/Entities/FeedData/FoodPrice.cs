using System;
namespace FeedExpenseCalculator.Service.Entities.FeedData
{
    public class FoodPrice
    {
        public int Id { get; set; }
        public FoodType FoodType { get; set; }
        public decimal Price { get; set; }
    }

    public enum FoodType
    {
        Fruit = 0,
        Meat = 1,
        Both = 2
    }
}
