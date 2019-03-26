using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class TransactionRetentiveDTO
    {
        public int TransactionRetentiveId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public decimal Price { get; set; }
        public DateTime DueDate { get; set; }

        public virtual ICollection<TransactionDTO> Transaction { get; set; }
    }
}
