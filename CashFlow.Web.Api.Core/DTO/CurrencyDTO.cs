using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class CurrencyDTO
    {
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PurchaseDTO> Purchase { get; set; }
    }
}
