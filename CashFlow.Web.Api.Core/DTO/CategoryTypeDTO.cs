using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class CategoryTypeDTO
    {
        public int CategoryTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<CategoryDTO> Category { get; set; }
    }
}
