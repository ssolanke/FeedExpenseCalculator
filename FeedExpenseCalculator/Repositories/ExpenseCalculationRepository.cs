using System.Collections.Generic;
using FeedExpenseCalculator.Service.Entities.FeedData;
using FeedExpenseCalculator.Service.Interfaces;

namespace FeedExpenseCalculator.Service.Repositories
{
    public class ExpenseCalculationRepository : IExpenseCalculationRepository
    {
        public ExpenseCalculationRepository()
        {
            // create the data from text,csv and xml file
        }

        public List<Animal> GetAnimals()
        {
            //get the data from context objects createds
            throw new System.NotImplementedException();
        }
    }
}
