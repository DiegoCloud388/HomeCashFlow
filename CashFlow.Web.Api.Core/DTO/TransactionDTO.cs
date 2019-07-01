using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class TransactionDTO
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

        public virtual AccountDTO Account { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual PurchaseDTO Purchase { get; set; }
        public virtual TransactionRetentiveDTO TransactionRetentive { get; set; }
        public virtual TransactionTypeDTO TransactionType { get; set; }
    }
}
