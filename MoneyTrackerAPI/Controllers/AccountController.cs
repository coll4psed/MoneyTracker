﻿using AutoMapper;
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
        public async Task<ActionResult<IEnumerable<AccountWithoutExpenseAndIncomeDto>>> GetAccounts()
        {
            var accounts = await _accountRepository.GetAccountsAsync();

            return Ok(_mapper.Map<IEnumerable<AccountWithoutExpenseAndIncomeDto>>(accounts));
        }

        [HttpGet("{accountid}", Name = "GetAccount")]
        public async Task<ActionResult<AccountWithoutExpenseAndIncomeDto>> GetAccount(
            int accountId)
        {
            var account = await _accountRepository
                .GetAccountAsync(accountId);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AccountWithoutExpenseAndIncomeDto>(account));
        }

        [HttpPost]
        public async Task<ActionResult<AccountWithoutExpenseAndIncomeDto>> CreateAccount(
            AccountForCreationDto account)
        {
            var finalAccount = _mapper.Map<Account>(account);

            _accountRepository.AddAccount(finalAccount);

            await _accountRepository.SaveChangesAsync();

            var createdAccountToReturn =
                _mapper.Map<AccountWithoutExpenseAndIncomeDto>(finalAccount);

            return CreatedAtRoute("GetAccount",
                new
                {
                    accountId = createdAccountToReturn.Id
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
        public async Task<ActionResult> PartiallyUpdateAccountInfo(
            int accountId,
            JsonPatchDocument<AccountForUpdateDto> patchDocument)
        {
            var accountEntity = await _accountRepository
                .GetAccountAsync(accountId);

            if (accountEntity == null)
            {
                return NotFound();
            }

            var accountToPatch = _mapper
                .Map<AccountForUpdateDto>(accountEntity);

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

        [HttpDelete("{accountId}")]
        public async Task<ActionResult> DeleteAccount(
            int accountId)
        {
            var accountEntity = await _accountRepository
                .GetAccountAsync(accountId);

            if (accountEntity == null)
            {
                return NotFound();
            }

            _accountRepository.DeleteAccount(accountEntity);
            
            await _accountRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
