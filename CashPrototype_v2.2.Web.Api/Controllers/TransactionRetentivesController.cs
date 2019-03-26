using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Core.DTO;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionRetentivesController : ControllerBase
    {
        private readonly IServiceTransactionRetentive _service;
        private ILogger<TransactionRetentivesController> Log;

        public TransactionRetentivesController(IServiceTransactionRetentive service, ILogger<TransactionRetentivesController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET: api/TransactionRetentives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionRetentiveDTO>>> GetTransactionRetentives()
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

        // GET: api/TransactionRetentives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionRetentiveDTO>> GetTransactionRetentive(int id)
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

        // PUT: api/TransactionRetentives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionRetentive(int id, TransactionRetentiveDTO transactionRetentiveDTO)
        {
            if (id != transactionRetentiveDTO.TransactionRetentiveId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.UpdateItem(transactionRetentiveDTO);

                return CreatedAtAction("GetTransactionRetentive", new { id = transactionRetentiveDTO.TransactionRetentiveId }, id);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // POST: api/TransactionRetentives
        [HttpPost]
        public async Task<ActionResult> PostTransactionRetentive(TransactionRetentiveDTO transactionRetentiveDTO)
        {
            try
            {
                await _service.InsertItem(transactionRetentiveDTO);

                return CreatedAtAction("GetTransactionRetentive", new { id = transactionRetentiveDTO.TransactionRetentiveId }, transactionRetentiveDTO);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // DELETE: api/TransactionRetentives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransactionRetentive(int id)
        {
            if (id != _service.GetItemById(id).Result.TransactionRetentiveId)
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
