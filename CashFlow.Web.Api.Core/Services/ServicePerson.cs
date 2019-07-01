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
    public class ServicePerson : IServicePerson
    {
        private readonly CashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServicePerson(CashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteItem(int id)
        {
            var person = await _dbContext.People.FindAsync(id);

            _dbContext.People.Remove(person);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<PersonDTO>> GetAllItems()
        {
            return await _mapper.Map<Task<List<PersonDTO>>>(_dbContext.People.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PersonDTO> GetItemById(int id)
        {
            return await _mapper.Map<Task<PersonDTO>>(_dbContext.People.FindAsync(id));
        }

        public async Task InsertItem(PersonDTO person)
        {
            var personEntity = _mapper.Map<Person>(person);

            _dbContext.People.Add(personEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(PersonDTO person)
        {
            var personEntity = _mapper.Map<Person>(person);

            _dbContext.People.Update(personEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
