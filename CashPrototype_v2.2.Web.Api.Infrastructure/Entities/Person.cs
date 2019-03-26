using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class Person
    {
        public Person()
        {
            Account = new HashSet<Account>();
        }

        public int PersonId { get; set; }
        public int PPersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public virtual PersonType PPersonType { get; set; }
        public virtual ICollection<Account> Account { get; set; }
    }
}
