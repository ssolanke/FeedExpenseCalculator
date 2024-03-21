using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using FeedExpenseCalculator.Service.Entities;
using FeedExpenseCalculator.Service.Entities.FeedData;
using FeedExpenseCalculator.Service.Helpers;
using FeedExpenseCalculator.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace FeedExpenseCalculator.Service.Repositories
{
    public class ExpenseCalculationRepository : IExpenseCalculationRepository
    {
        public ExpenseCalculationRepository()
        {
            using (var context = new ApiContext())
            {
                // create the in-memory data from text,csv and xml file
                var prices = new List<FoodPrice>();
                FileReaderHelper.GetFoodPriceFromTextFile(prices);

                var animalsInfo = new List<Animal>();

                FileReaderHelper.GetAnimalsInfoFromCSVFile(animalsInfo);
                context.Animals.AddRange(animalsInfo);
                context.FoodPrices.AddRange(prices);
                context.SaveChanges();
            }
        }

        public decimal GetPriceForOneDayForAllZooAnimals()
        {
            decimal Total = 0;
            decimal oneDayPriceForAnAnimal = 0;
                using (var context = new ApiContext())
                {
                    var list = context.Animals.ToList();
                    var prices = context.FoodPrices.ToList();

                    var xmlDocumentText = "DataFiles/zoo.xml";
                    if (File.Exists(xmlDocumentText))
                    {
                        XmlTextReader textReader = new XmlTextReader(xmlDocumentText);
                        textReader.Read();
                        while (textReader.Read())
                        {
                            textReader.MoveToContent();
                            var animalName = textReader.LocalName;
                            var animalFromDb = list.Where(a => a.Name == animalName).FirstOrDefault();
                            if (animalFromDb != null)
                            {
                                textReader.MoveToAttribute(1);
                                var zooAnimalWeight = Convert.ToDecimal(textReader.Value);
                                var fruitPrice = prices.Where(p => p.FoodType == FoodType.Fruit).FirstOrDefault().Price;
                                var meatPrice = prices.Where(p => p.FoodType == FoodType.Meat).FirstOrDefault().Price;

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
                                    oneDayPriceForAnAnimal = meatPrice * animalFromDb.Rate * zooAnimalWeight * (int)animalFromDb.PercentageOfMeat / 100 +
                                                    fruitPrice * animalFromDb.Rate * zooAnimalWeight * ((100 - (int)animalFromDb.PercentageOfMeat) / 100);
                                }

                                Total = Total + oneDayPriceForAnAnimal;
                            }

                        }

                    }
                }
            return Total;
        }
    }
}

