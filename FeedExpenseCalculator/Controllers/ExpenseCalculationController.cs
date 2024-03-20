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
            (bool, decimal) response = (false, 0); 
            try
            {
                var result = _expenseCalculationRepository.GetPriceForOneDayForAllZooAnimals();
                response = (true, result);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return new JsonResult(response);
        }
    }
}
