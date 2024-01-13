using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Entities;
using MoneyTrackerAPI.Models.Account;
using MoneyTrackerAPI.Services.AccountServices;

namespace MoneyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ??
                throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var accounts = await _accountRepository.GetAccountsAsync();

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accounts));
        }

        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountRepository.GetAccountAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AccountDto>(account));
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccount(
            Account account)
        {
            var finalAccount = _mapper.Map<Account>(account);

            _accountRepository.AddAccount(account);

            await _accountRepository.SaveChangesAsync();

            var createdAccountToReturn =
                _mapper.Map<AccountDto>(finalAccount);

            return CreatedAtRoute("GetAccount",
                new
                {
                    id = createdAccountToReturn.Id
                },
                createdAccountToReturn);
        }

        [HttpPut("{accountid}")]
        public async Task<ActionResult> UpdateAccountInfo(
            int accountId,
            AccountForUpdateDto account)
        {
            var accountEntity = await _accountRepository
                .GetAccountAsync(accountId);

            if (accountEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(account, accountEntity);

            await _accountRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{accountid}")]
        public async Task<ActionResult> PartiallyUpdateAccount(
            int accId,
            JsonPatchDocument<AccountForUpdateDto> patchDocument)
        {
            var accountEntity = await _accountRepository
                .GetAccountAsync(accId);

            if (accountEntity == null)
            {
                return NotFound();
            }

            var accountToPatch = _mapper.Map<AccountForUpdateDto>(
                accountEntity);

            patchDocument.ApplyTo(accountToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(accountToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(accountToPatch, accountEntity);

            await _accountRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
