using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int TAccountIdFk { get; set; }
        public int TTransactionTypeIdFk { get; set; }
        public int TPurchaseIdFk { get; set; }
        public int TCategoryIdFk { get; set; }
        public int? TTransactionRetentIdFk { get; set; }
        public string LoggedUser { get; set; }

        public virtual Account TAccountIdFkNavigation { get; set; }
        public virtual Category TCategoryIdFkNavigation { get; set; }
        public virtual Purchase TPurchaseIdFkNavigation { get; set; }
        public virtual TransactionRetentive TTransactionRetentIdFkNavigation { get; set; }
        public virtual TransactionType TTransactionTypeIdFkNavigation { get; set; }
    }
}
