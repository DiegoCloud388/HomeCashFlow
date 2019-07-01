using AutoMapper;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities;
using CashPrototype_v2._2.Web.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashPrototype_v2._2.Web.Api.Core.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceCategory(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Delete category item by Id from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteItem(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Find all categories.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<CategoryDTO>>>(_dbContext.Categories.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<CategoryDTO>>(_dbContext.Categories.FindAsync(id));
        }

        /// <summary>
        /// Insert category item into database.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task InsertItem(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);

            _dbContext.Categories.Add(categoryEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);

            _dbContext.Categories.Update(categoryEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
