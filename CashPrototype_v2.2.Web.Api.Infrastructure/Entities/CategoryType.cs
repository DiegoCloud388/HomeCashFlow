using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Entities
{
    public partial class CategoryType
    {
        public CategoryType()
        {
            Category = new HashSet<Category>();
        }

        public int CategoryTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
