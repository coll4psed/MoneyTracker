using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Entities;
using MoneyTrackerAPI.Models.Category;
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

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> CreateExpense(
            ExpenseForCreationDto expense)
        {
            var finalExpense = _mapper
                .Map<Expense>(expense);

            _expenseRepository
                .AddExpense(finalExpense);

            await _expenseRepository
                .SaveChangesAsync();

            var createdExpenseToReturn =
                _mapper.Map<ExpenseDto>(finalExpense);

            return CreatedAtRoute("GetExpense",
                new
                {
                    expenseid = createdExpenseToReturn.Id
                },
                createdExpenseToReturn);
        }

        [HttpPatch("{expenseid}")]
        public async Task<ActionResult> PartiallyUpdateExpenseInfo(
            int expenseId,
            JsonPatchDocument<ExpenseForUpdateDto> patchDocument)
        {
            var expenseEntity = await _expenseRepository
                .GetExpenseAsync(expenseId);

            if (expenseEntity == null)
            {
                return NotFound();
            }

            var expenseToPatch = _mapper
                .Map<ExpenseForUpdateDto>(expenseEntity);

            patchDocument.ApplyTo(expenseToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(expenseToPatch))
            {
                return BadRequest();
            }

            _mapper.Map(expenseToPatch, expenseEntity);

            await _expenseRepository
                .SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{expenseid}")]
        public async Task<ActionResult> DeleteAccount(
            int expenseId)
        {
            var expenseEntity = await _expenseRepository
                .GetExpenseAsync(expenseId);

            if (expenseEntity == null)
            {
                return NotFound();
            }

            _expenseRepository
                .DeleteExpense(expenseEntity);

            await _expenseRepository
                .SaveChangesAsync();

            return NoContent();
        }
    }
}
