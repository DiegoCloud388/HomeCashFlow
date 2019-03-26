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
    public class ServiceTransactionType : IServiceTransactionType
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceTransactionType(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteItem(int id)
        {
            var transactionType = await _dbContext.TransactionTypes.FindAsync(id);

            _dbContext.TransactionTypes.Remove(transactionType);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TransactionTypeDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<TransactionTypeDTO>>>(_dbContext.TransactionTypes.ToListAsync());
        }

        public async Task<TransactionTypeDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<TransactionTypeDTO>>(_dbContext.TransactionTypes.FindAsync(id));
        }

        public async Task InsertItem(TransactionTypeDTO transactionType)
        {
            var transactionTypeEntity = _mapper.Map<TransactionType>(transactionType);

            _dbContext.TransactionTypes.Add(transactionTypeEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(TransactionTypeDTO transactionType)
        {
            var transactionTypeEntity = _mapper.Map<TransactionType>(transactionType);

            _dbContext.TransactionTypes.Update(transactionTypeEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
