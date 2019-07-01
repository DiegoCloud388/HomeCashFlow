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
    public class ServiceCurrency : IServiceCurrency
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceCurrency(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteItem(string id)
        {
            var currency = await _dbContext.Currencies.FindAsync(id);

            _dbContext.Currencies.Remove(currency);

            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CurrencyDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<CurrencyDTO>>>(_dbContext.Currencies.ToListAsync());
        }

        public async Task<CurrencyDTO> GetItemById(string id)
        {
            return await _mapper.Map<Task<CurrencyDTO>>(_dbContext.Currencies.FindAsync(id));
        }

        public Task<CurrencyDTO> GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertItem(CurrencyDTO currencyDTO)
        {
            var accountEntity = _mapper.Map<Account>(currencyDTO);

            _dbContext.Accounts.Add(accountEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(CurrencyDTO currency)
        {
            var currencyEntity = _mapper.Map<Currency>(currency);

            _dbContext.Currencies.Update(currencyEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
