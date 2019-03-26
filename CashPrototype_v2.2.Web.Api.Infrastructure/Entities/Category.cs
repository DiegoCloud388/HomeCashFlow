using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class Category
    {
        public Category()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string Description { get; set; }
        public int CategoryTypeIdFk { get; set; }

        public virtual CategoryType CategoryType { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
