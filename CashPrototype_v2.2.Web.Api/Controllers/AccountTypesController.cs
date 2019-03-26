using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using Microsoft.Extensions.Logging;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private readonly IServiceAccountType _service;
        private ILogger<AccountTypesController> Log;

        public AccountTypesController(IServiceAccountType service, ILogger<AccountTypesController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET: api/AccountTypes
        [HttpGet]
        public async Task<ActionResult<List<AccountTypeDTO>>> GetAccountTypes()
        {
            try
            {
                return await _service.GetAllItems();
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při čtení z databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // GET: api/AccountTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTypeDTO>> GetAccountType(int id)
        {
            try
            {
                return await _service.GetItemById(id);            
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při čtení z databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // PUT: api/AccountTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountType(int id, AccountTypeDTO accountType)
        {
            if (id != accountType.AccountTypeId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.UpdateItem(accountType);

                return CreatedAtAction("GetAccountType", new { id = accountType.AccountTypeId }, id);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // POST: api/AccountTypes
        [HttpPost]
        public async Task<ActionResult> PostAccountType(AccountTypeDTO accountType)
        {
            try
            {
                await _service.InsertItem(accountType);

                return CreatedAtAction("GetAccountType", new { id = accountType.AccountTypeId }, accountType);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // DELETE: api/AccountTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccountType(int id)
        {
            if (id != _service.GetItemById(id).Result.AccountTypeId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.DeleteItem(id);

                return Ok();
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }
    }
}
