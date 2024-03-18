xusing System.Collections.Generic;
using FeedExpenseCalculator.Service.Entities.FeedData;

namespace FeedExpenseCalculator.Service.Interfaces
{
    public interface IExpenseCalculationRepository
    {
        public List<Animal> GetAnimals();
    }
}
