using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Core.DTO;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypesController : ControllerBase
    {
        private readonly IServiceTransactionType _service;
        private ILogger<TransactionTypesController> Log;

        public TransactionTypesController(IServiceTransactionType service, ILogger<TransactionTypesController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET: api/TransactionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionTypeDTO>>> GetTransactionTypes()
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

        // GET: api/TransactionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionTypeDTO>> GetTransactionType(int id)
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

        // PUT: api/TransactionTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionType(int id, TransactionTypeDTO transactionTypeDTO)
        {
            if (id != transactionTypeDTO.TransactionTypeId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.UpdateItem(transactionTypeDTO);

                return CreatedAtAction("GetTransactionType", new { id = transactionTypeDTO.TransactionTypeId }, id);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // POST: api/TransactionTypes
        [HttpPost]
        public async Task<ActionResult> PostTransactionType(TransactionTypeDTO transactionTypeDTO)
        {
            try
            {
                await _service.InsertItem(transactionTypeDTO);

                return CreatedAtAction("GetTransactionType", new { id = transactionTypeDTO.TransactionTypeId }, transactionTypeDTO);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // DELETE: api/TransactionTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransactionType(int id)
        {
            if (id != _service.GetItemById(id).Result.TransactionTypeId)
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
