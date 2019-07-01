using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class UserDTO : IdentityUser<int>
    {
        public string UserLastName { get; set; }
    }
}
