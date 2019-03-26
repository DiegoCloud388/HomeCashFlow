using AutoMapper;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities;
using CashPrototype_v2._2.Web.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashPrototype_v2._2.Web.Api.Core.Services
{
    public class ServiceCategoryType : IServiceCategoryType
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceCategoryType(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Find categoryType item by Id and delete this item. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteItem(int id)
        {
            var categoryType = await _dbContext.CategoryTypes.FindAsync(id);

            _dbContext.CategoryTypes.Remove(categoryType);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Find all categoryTypes in database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryTypeDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<CategoryTypeDTO>>>(_dbContext.CategoryTypes.ToListAsync());
        }

        /// <summary>
        /// Find categroyType item by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryTypeDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<CategoryTypeDTO>>(_dbContext.CategoryTypes.FindAsync(id));
        }

        /// <summary>
        /// Insert item categoryType to table and save.
        /// </summary>
        /// <param name="categoryType"></param>
        /// <returns></returns>
        public async Task InsertItem(CategoryTypeDTO categoryType)
        {
            var categoryTypeEntity = _mapper.Map<CategoryType>(categoryType);

            _dbContext.CategoryTypes.Add(categoryTypeEntity);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryTypeDTO"></param>
        /// <returns></returns>
        public async Task UpdateItem(CategoryTypeDTO categoryTypeDTO)
        {
            var categoryTypeEntity = _mapper.Map<CategoryType>(categoryTypeDTO);

            _dbContext.CategoryTypes.Update(categoryTypeEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
