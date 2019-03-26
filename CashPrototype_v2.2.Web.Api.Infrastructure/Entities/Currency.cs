using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class Currency
    {
        public Currency()
        {
            Purchase = new HashSet<Purchase>();
        }

        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
