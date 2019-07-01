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
    public class ServicePurchase : IServicePurchase
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServicePurchase(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteItem(int id)
        {
            var purchase = await _dbContext.Purchases.FindAsync(id);

            _dbContext.Purchases.Remove(purchase);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PurchaseDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<PurchaseDTO>>>(_dbContext.Purchases.ToListAsync());
        }

        public async Task<PurchaseDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<PurchaseDTO>>(_dbContext.Purchases.FindAsync(id));
        }

        public async Task InsertItem(PurchaseDTO purchaseDTO)
        {
            var purchase = _mapper.Map<Purchase>(purchaseDTO);

            _dbContext.Purchases.Add(purchase);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(PurchaseDTO purchaseDTO)
        {
            var purchase = _mapper.Map<Purchase>(purchaseDTO);

            _dbContext.Purchases.Update(purchase);

            await _dbContext.SaveChangesAsync();
        }
    }
}
