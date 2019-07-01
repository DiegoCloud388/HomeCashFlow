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
    public class ServicePersonType : IServicePersonType
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServicePersonType(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteItem(int id)
        {
            var personType = await _dbContext.PersonTypes.FindAsync(id);

            _dbContext.PersonTypes.Remove(personType);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<PersonTypeDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<PersonTypeDTO>>>(_dbContext.PersonTypes.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PersonTypeDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<PersonTypeDTO>>(_dbContext.PersonTypes.FindAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personTypeDTO"></param>
        /// <returns></returns>
        public async Task InsertItem(PersonTypeDTO personTypeDTO)
        {
            var personType = _mapper.Map<PersonType>(personTypeDTO);

            _dbContext.PersonTypes.Add(personType);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(PersonTypeDTO personTypeDTO)
        {
            var personType = _mapper.Map<PersonType>(personTypeDTO);

            _dbContext.PersonTypes.Update(personType);

            await _dbContext.SaveChangesAsync();
        }
    }
}
