using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using Microsoft.Extensions.Logging;
using CashPrototype_v2._2.Web.Api.Core.DTO;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IServicePurchase _service;
        private ILogger<PurchasesController> Log;

        public PurchasesController(IServicePurchase service, ILogger<PurchasesController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPurchases()
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

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchase(int id)
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

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, PurchaseDTO purchaseDTO)
        {
            if (id != purchaseDTO.PurchaseId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.UpdateItem(purchaseDTO);

                return CreatedAtAction("GetPurchase", new { id = purchaseDTO.PurchaseId }, id);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult> PostPurchase(PurchaseDTO purchaseDTO)
        {
            try
            {
                await _service.InsertItem(purchaseDTO);

                return CreatedAtAction("GetPurchase", new { id = purchaseDTO.PurchaseId }, purchaseDTO);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePurchase(int id)
        {
            if (id != _service.GetItemById(id).Result.PurchaseId)
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
