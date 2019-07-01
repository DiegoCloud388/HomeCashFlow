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
    public class ServiceAccountType : IServiceAccountType
    {
        private readonly IMapper _mapper;
        private readonly CashDbContext _dbContext;

        public ServiceAccountType(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Delete account type by id from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteItem(int id)
        {
            var accountType = await _dbContext.AccountTypes.FindAsync(id);

            _dbContext.AccountTypes.Remove(accountType);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccountTypeDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<AccountTypeDTO>>(_dbContext.AccountTypes.FindAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AccountTypeDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<AccountTypeDTO>>>(_dbContext.AccountTypes.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public async Task InsertItem(AccountTypeDTO accountType)
        {
            var accountTypeEntity = _mapper.Map<AccountType>(accountType);

            _dbContext.AccountTypes.Add(accountTypeEntity);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public async Task UpdateItem(AccountTypeDTO accountType)
        {
            var accountTypeEntity = _mapper.Map<AccountType>(accountType);

            _dbContext.AccountTypes.Update(accountTypeEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
