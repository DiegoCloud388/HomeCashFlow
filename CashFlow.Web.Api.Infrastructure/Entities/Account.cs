using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        public int? BankCode { get; set; }
        public string Name { get; set; }
        public decimal FirstBalanceRange { get; set; }
        public int AcAccountTypeIdFk { get; set; }
        public int AcPersonIdFk { get; set; }
        public string Description { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
