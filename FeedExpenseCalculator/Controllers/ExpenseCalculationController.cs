using System;
using FeedExpenseCalculator.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeedExpenseCalculator.Service.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExpenseCalculationController : ControllerBase
    {
        private readonly ILogger<ExpenseCalculationController> _logger;
        private readonly IExpenseCalculationRepository _expenseCalculationRepository;

        public ExpenseCalculationController(ILogger<ExpenseCalculationController> logger, IExpenseCalculationRepository expenseCalculationRepository)
        {
            _logger = logger;
            _expenseCalculationRepository = expenseCalculationRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            decimal result = 0;
            try
            {
                result = _expenseCalculationRepository.GetPriceForOneDayForAllZooAnimals();
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return new JsonResult(result);
        }
    }
}
