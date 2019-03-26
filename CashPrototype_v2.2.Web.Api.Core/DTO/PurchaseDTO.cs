using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class PurchaseDTO
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string PuCurrencyId { get; set; }
        public string Description { get; set; }

        public CurrencyDTO Currency { get; set; }
        public virtual ICollection<TransactionDTO> Transaction { get; set; }
    }
}
