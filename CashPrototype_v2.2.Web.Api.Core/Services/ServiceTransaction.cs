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
    public class ServiceTransaction : IServiceTransaction
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceTransaction(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteItem(int id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);

            _dbContext.Transactions.Remove(transaction);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TransactionDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<TransactionDTO>>>(_dbContext.Transactions.ToListAsync());
        }

        public async Task<TransactionDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<TransactionDTO>>(_dbContext.Transactions.FindAsync(id));
        }

        public async Task InsertItem(TransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);

            _dbContext.Transactions.Add(transaction);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(TransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);

            _dbContext.Transactions.Update(transaction);

            await _dbContext.SaveChangesAsync();
        }
    }
}
