using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypesController : ControllerBase
    {
        private readonly IServicePersonType _service;
        private ILogger<PersonTypesController> Log;

        public PersonTypesController(IServicePersonType service, ILogger<PersonTypesController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET: api/PersonTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonTypeDTO>>> GetPersonTypes()
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

        // GET: api/PersonTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonTypeDTO>> GetPersonType(int id)
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

        // PUT: api/PersonTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonType(int id, PersonTypeDTO personTypeDTO)
        {
            if (id != personTypeDTO.PersonTypeId)
            {
                Log.LogError($"Chyba!!! Záznam s tímto Id nebyl nalezen.");
                return BadRequest();
            }

            try
            {
                await _service.UpdateItem(personTypeDTO);

                return CreatedAtAction("GetPersonType", new { id = personTypeDTO.PersonTypeId }, id);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // POST: api/PersonTypes
        [HttpPost]
        public async Task<ActionResult<PersonTypeDTO>> PostPersonType(PersonTypeDTO personTypeDTO)
        {
            try
            {
                await _service.InsertItem(personTypeDTO);

                return CreatedAtAction("GetPersonType", new { id = personTypeDTO.PersonTypeId }, personTypeDTO);
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při ukládání do databáze: {ex.InnerException}");
                return NotFound();
            }
        }

        // DELETE: api/PersonTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonTypeDTO>> DeletePersonType(int id)
        {
            if (id != _service.GetItemById(id).Result.PersonTypeId)
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

        private bool PersonTypeExists(int id)
        {
            return _service.GetItemById(id).Result.PersonTypeId == id;
        }
    }
}
