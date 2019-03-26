using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        //public string UserLastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
