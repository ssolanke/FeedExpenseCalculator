using System;
using FeedExpenseCalculator.Service.Controllers;
using FeedExpenseCalculator.Service.Interfaces;
using FeedExpenseCalculator.Service.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ExpenseCalculationTest
{
    public class ExpenseCalculationControllersTest
    {
        ExpenseCalculationController _expenseCalculationController;
        IExpenseCalculationRepository _expenseCalculationRepository;
        ILogger<ExpenseCalculationController> _logger;

        public ExpenseCalculationControllersTest()
        {
            _expenseCalculationRepository = new ExpenseCalculationRepository();
            _expenseCalculationController = new ExpenseCalculationController(_logger, _expenseCalculationRepository);
        }

        [Fact]
        public void Test1()
        {
            //Arrange
            //Act
            var result = _expenseCalculationController.Get();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
