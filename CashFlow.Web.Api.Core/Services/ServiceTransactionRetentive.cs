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
    public class ServiceTransactionRetentive : IServiceTransactionRetentive
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceTransactionRetentive(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteItem(int id)
        {
            var transactionRetentive = await _dbContext.TransactionRetentives.FindAsync(id);

            _dbContext.TransactionRetentives.Remove(transactionRetentive);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TransactionRetentiveDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<TransactionRetentiveDTO>>>(_dbContext.TransactionRetentives.ToListAsync());
        }

        public async Task<TransactionRetentiveDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<TransactionRetentiveDTO>>(_dbContext.TransactionRetentives.FindAsync(id));
        }

        public async Task InsertItem(TransactionRetentiveDTO transactionRetentiveDTO)
        {
            var transactionRetentive = _mapper.Map<TransactionRetentive>(transactionRetentiveDTO);

            _dbContext.TransactionRetentives.Add(transactionRetentive);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(TransactionRetentiveDTO transactionRetentiveDTO)
        {
            var transactionRetentive = _mapper.Map<TransactionRetentive>(transactionRetentiveDTO);

            _dbContext.TransactionRetentives.Update(transactionRetentive);

            await _dbContext.SaveChangesAsync();
        }
    }
}
