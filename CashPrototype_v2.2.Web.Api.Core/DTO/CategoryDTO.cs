using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string Description { get; set; }
        public int CategoryTypeIdFk { get; set; }

        public virtual CategoryTypeDTO CategoryType { get; set; }
        public virtual ICollection<TransactionDTO> Transaction { get; set; }
    }
}
