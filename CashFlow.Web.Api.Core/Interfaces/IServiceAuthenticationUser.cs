using CashPrototype_v2._2.Web.Api.Core.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashPrototype_v2._2.Web.Api.Core.Interfaces
{
    public interface IServiceAuthenticationUser
    {
        Task<IdentityResult> RegistrationUser(UserDTO userDTO);

        Task LogInUser(UserDTO userDTO);

        Task LogOutUser(UserDTO userDTO);
    }
}
