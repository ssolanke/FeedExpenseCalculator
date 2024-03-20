using System;
using System.Collections.Generic;
using System.IO;
using FeedExpenseCalculator.Service.Entities.FeedData;
using Microsoft.VisualBasic.FileIO;

namespace FeedExpenseCalculator.Service.Helpers
{
    public static class FileReaderHelper
    {
        public static void GetFoodPriceFromTextFile(List<FoodPrice> prices)
        {
            var textFile = "DataFiles/prices.txt";
            if (File.Exists(textFile))
            {
                // Read file using StreamReader. Reads file line by line
                using (StreamReader file = new StreamReader(textFile))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        var col = ln.Split('=');
                        var foodType = col[0] == FoodType.Fruit.ToString() ? FoodType.Fruit : FoodType.Meat;
                        prices.Add(new FoodPrice()
                        {
                            FoodType = foodType,
                            Price = Convert.ToDecimal(col[1])
                        });
                        counter++;
                    }
                    file.Close();
                }
            }
        }

        public static void GetAnimalsInfoFromCSVFile(List<Animal> animals)
        {
            var csvFile = "DataFiles/animals.csv";
            if (File.Exists(csvFile))
            {
                using (TextFieldParser csvParser = new TextFieldParser(csvFile))
                {
                    csvParser.SetDelimiters(new string[] { ";" });
                    csvParser.TrimWhiteSpace = true;
                    csvParser.HasFieldsEnclosedInQuotes = false;
                    while (!csvParser.EndOfData)
                    {
                    // Read current line fields, pointer moves to the next line.
                        string[] fields = csvParser.ReadFields();
                        if (fields[0].Contains(','))
                        {
                            break;
                        }
                        animals.Add(new Animal()
                        {
                            Name = fields[0],
                            Rate = Convert.ToDecimal(fields[1]),
                            FoodType = Enum.Parse<FoodType>(fields[2],true),
                            PercentageOfMeat = string.IsNullOrEmpty(fields[3].Trim(',')) ? 100 : Convert.ToDecimal(fields[3].Trim(',').Trim('%'))
                        });
                    }
                }

            }
        }
    }
}
