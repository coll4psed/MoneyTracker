using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Models.Expense;
using MoneyTrackerAPI.Services.ExpenseServices;

namespace MoneyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository ??
                throw new ArgumentNullException(nameof(expenseRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
        {
            var expenses = await _expenseRepository.GetExpensesAsync();

            return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(expenses));
        }

        [HttpGet("{expenseid}", Name = "GetExpense")]
        public async Task<ActionResult<ExpenseDto>> GetExpense(
            int expenseId)
        {
            var expense = await _expenseRepository
                .GetExpenseAsync(expenseId);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ExpenseDto>(expense));
        }
    }
}
