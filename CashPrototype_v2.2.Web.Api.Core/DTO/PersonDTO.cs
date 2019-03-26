using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.DTO
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public int PPersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public virtual PersonTypeDTO PPersonType { get; set; }
        public virtual ICollection<AccountDTO> Account { get; set; }
    }
}
