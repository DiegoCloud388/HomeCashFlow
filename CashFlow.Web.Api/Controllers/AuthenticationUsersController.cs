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

        // POST: api/AuthenticationUsers/Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> PostUser(UserDTO userDTO)
        {
            try
            {
                var result = await _service.RegistrationUser(userDTO);
                if (result.Succeeded)
                {
                    Log.LogInformation("User created a new account with password.");
                    return Ok();
                }

                else
                {
                    Log.LogInformation("User cannot created a new account with password.");
                    return BadRequest();
                }
            }

            catch (Exception ex)
            {
                Log.LogError($"Chyba při zápisu do databáze: {ex.InnerException}, {ex.Message}, {ex.Data}, {ex.Source}, {ex.StackTrace}");
                return NotFound();
            }
        }
    }
}