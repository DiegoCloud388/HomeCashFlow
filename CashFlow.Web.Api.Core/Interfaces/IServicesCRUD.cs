using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashPrototype_v2._2.Web.Api.Core.Interfaces
{
    public interface IServicesCRUD<TEntityDTO> where TEntityDTO : class
    {
        Task<List<TEntityDTO>> GetAllItems();

        Task<TEntityDTO> GetItemById(int id);

        Task InsertItem(TEntityDTO entityDTO);

        Task UpdateItem(TEntityDTO entityDTO);

        Task DeleteItem(int id);
    }
}
