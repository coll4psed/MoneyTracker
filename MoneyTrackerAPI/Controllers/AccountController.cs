using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Interfaces;
using MoneyTrackerAPI.Models;

namespace MoneyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IBaseRepository _repository;

        public AccountController(IBaseRepository baseRepository)
        {
            _repository = baseRepository ??
                throw new ArgumentNullException(nameof(baseRepository));
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.Create<Account>(a);
            await _repository.SaveAsync();
            return Ok(data.Entity);
        }
    }
}
