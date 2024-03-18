using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedExpenseCalculator.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeedExpenseCalculator.Service.Controllers
{
    [ApiController]
    [Route("[api/v1/FeedExpense]")]
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
        [Authorize(Policy = "ApiKey")]
        public JsonResult Get()
        {
            var result = _expenseCalculationRepository.GetAnimals();
            return new JsonResult(result);
        }
    }
}
