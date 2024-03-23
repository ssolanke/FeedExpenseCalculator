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
        public IActionResult Get()
        {
            try
            {
                var inputZooXmlFile = "DataFiles/zoo.xml";
                var result = _expenseCalculationRepository.GetPriceForOneDayForAllZooAnimals(inputZooXmlFile);
                return Ok(new JsonResult(result));
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
