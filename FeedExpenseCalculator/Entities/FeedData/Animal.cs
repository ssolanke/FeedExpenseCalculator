using System;
namespace FeedExpenseCalculator.Service.Entities.FeedData
{
    public class Animal
    {
        public string Name { get; set; }
        public decimal RateOfFood { get; set; }
        public AnimalFoodType AnimalFoodType { get; set; }
        public decimal? PercentageOfMeat { get; set; }
    }

    public enum AnimalFoodType
    {
        Fruit = FoodType.Fruit,
        Meat = FoodType.Meat,
        FruitAndMeat = 2
    }
}
