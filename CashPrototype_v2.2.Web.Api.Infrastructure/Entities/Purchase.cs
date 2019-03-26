using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class Purchase
    {
        public Purchase()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string PuCurrencyId { get; set; }
        public string Description { get; set; }

        public virtual Currency PuCurrency { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
