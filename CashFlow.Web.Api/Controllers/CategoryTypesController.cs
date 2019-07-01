using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities;
using CashPrototype_v2._2.Web.Api.Infrastructure.Models;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using Microsoft.Extensions.Logging;
using CashPrototype_v2._2.Web.Api.Core.DTO;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTypesController : ControllerBase
    {
        private readonly IServiceCategoryType _service;
        private ILogger<CategoryTypesController> Log;

        public CategoryTypesController(IServiceCategoryType service, ILogger<CategoryTypesController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET: api/CategoryTypes
        [HttpGet]
        public async Task<ActionResult<List<CategoryTypeDTO>>> GetCategoryTypes()
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

        // GET: api/CategoryTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryTypeDTO>> GetCategoryType(int id)
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

        // PUT: api/CategoryTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryType(int id, CategoryTypeDTO categoryTypeDTO)
        {
            if (id != categoryTypeDTO.CategoryTypeId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.UpdateItem(categoryTypeDTO);

                return CreatedAtAction("GetCategoryType", new { id = categoryTypeDTO.CategoryTypeId }, id);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // POST: api/CategoryTypes
        [HttpPost]
        public async Task<ActionResult> PostCategoryType(CategoryTypeDTO categoryTypeDTO)
        {
            try
            {
                await _service.InsertItem(categoryTypeDTO);

                return CreatedAtAction("GetCategoryType", new { id = categoryTypeDTO.CategoryTypeId }, categoryTypeDTO);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }            
        }

        // DELETE: api/CategoryTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryType(int id)
        {
            if (id != _service.GetItemById(id).Result.CategoryTypeId)
            {
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
