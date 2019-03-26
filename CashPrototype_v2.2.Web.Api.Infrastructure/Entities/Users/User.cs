using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities.Users
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }

        public string EmailAddress { get; set; }

        public string UserPassword { get; set; }

    }
}
