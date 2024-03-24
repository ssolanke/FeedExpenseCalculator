using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using FeedExpenseCalculator.Service.Entities;
using FeedExpenseCalculator.Service.Entities.FeedData;
using FeedExpenseCalculator.Service.Helpers;
using FeedExpenseCalculator.Service.Interfaces;

namespace FeedExpenseCalculator.Service.Repositories
{
    public class ExpenseCalculationRepository : IExpenseCalculationRepository
    {
        public ExpenseCalculationRepository()
        {
            using (var context = new ApiContext())
            {
                // ToDo: as its a simple test project lets create the in-memory data. for now fetch here from text,csv and xml file
                var prices = new List<FoodPrice>();
                FileReaderHelper.GetFoodPriceFromTextFile(prices);
                var animalsInfo = new List<Animal>();
                FileReaderHelper.GetAnimalsInfoFromCSVFile(animalsInfo);
                context.Animals.AddRange(animalsInfo);
                context.FoodPrices.AddRange(prices);
                context.SaveChanges();
            }
        }

        public decimal GetPriceForOneDayForAllZooAnimals(string xmlDocumentText)
        {
            decimal Total = 0;
            decimal oneDayPriceForAnAnimal = 0;
            using (var context = new ApiContext())
            {
                var animalsFromDb = context.Animals.ToList();
                var pricesFromDb = context.FoodPrices.ToList();

                if (File.Exists(xmlDocumentText))
                {
                    XmlTextReader textReader = new XmlTextReader(xmlDocumentText);
                    while (textReader.Read())
                    {
                        textReader.MoveToContent();
                        var animalName = textReader.LocalName;
                        //ToDo:Use AutoMapper insetad of manual mapping.
                        var animalFromDb = animalsFromDb.Where(a => a.Name == animalName).FirstOrDefault();
                        if (animalFromDb != null)
                        {
                            textReader.MoveToAttribute(1);
                            var zooAnimalWeight = Convert.ToDecimal(textReader.Value);
                            var fruitPrice = pricesFromDb.Where(p => p.FoodType == FoodType.Fruit).FirstOrDefault().Price;
                            var meatPrice = pricesFromDb.Where(p => p.FoodType == FoodType.Meat).FirstOrDefault().Price;

                            if (animalFromDb.FoodType == FoodType.Fruit)
                            {
                                oneDayPriceForAnAnimal = fruitPrice * animalFromDb.Rate * zooAnimalWeight;
                            }
                            else if (animalFromDb.FoodType == FoodType.Meat)
                            {
                                oneDayPriceForAnAnimal = fruitPrice * animalFromDb.Rate * zooAnimalWeight;
                            }
                            else if (animalFromDb.FoodType == FoodType.Both)
                            {
                                oneDayPriceForAnAnimal = meatPrice * animalFromDb.Rate * zooAnimalWeight * (decimal)animalFromDb.PercentageOfMeat / 100 +
                                                fruitPrice * animalFromDb.Rate * zooAnimalWeight * ((100 - (decimal)animalFromDb.PercentageOfMeat) / 100);
                            }

                            Total += oneDayPriceForAnAnimal;
                        }
                    }
                }
            }
            return Math.Round(Total);
        }
    }
}

