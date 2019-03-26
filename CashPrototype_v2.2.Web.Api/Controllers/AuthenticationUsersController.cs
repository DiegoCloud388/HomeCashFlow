using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CashPrototype_v2._2.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationUsersController : ControllerBase
    {
        private readonly IServiceAuthenticationUser _service;
        private ILogger<AuthenticationUsersController> Log;

        public AuthenticationUsersController(IServiceAuthenticationUser service, ILogger<AuthenticationUsersController> log)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // POST: api/User/Register
        [HttpGet]
        [Route("Register")]
        public async Task<ActionResult> PostUser(UserDTO userDTO)
        {
            try
            {
                await _service.RegistrationUser(userDTO);

                return Ok();
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při čtení z databáze: {ex.InnerException}");
                return NotFound();
            }
        }
    }
}