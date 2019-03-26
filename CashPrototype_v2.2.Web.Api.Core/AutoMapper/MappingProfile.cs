using AutoMapper;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();

            CreateMap<AccountType, AccountTypeDTO>();
            CreateMap<AccountTypeDTO, AccountType>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<CategoryType, CategoryTypeDTO>();
            CreateMap<CategoryTypeDTO, CategoryType>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();

            CreateMap<PersonType, PersonTypeDTO>();
            CreateMap<PersonTypeDTO, PersonType>();

            CreateMap<Purchase, PurchaseDTO>();
            CreateMap<PurchaseDTO, Purchase>();

            CreateMap<Transaction, TransactionDTO>();
            CreateMap<TransactionDTO, Transaction>();

            CreateMap<TransactionRetentive, TransactionRetentiveDTO>();
            CreateMap<TransactionRetentiveDTO, TransactionRetentive>();

            CreateMap<TransactionType, TransactionTypeDTO>();
            CreateMap<TransactionTypeDTO, TransactionType>();
        }
    }
}
