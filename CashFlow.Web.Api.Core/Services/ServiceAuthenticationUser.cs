using AutoMapper;
using CashPrototype_v2._2.Web.Api.Core.DTO;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashPrototype_v2._2.Web.Api.Core.Services
{
    public class ServiceAuthenticationUser : IServiceAuthenticationUser
    {
        private UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ServiceAuthenticationUser(UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public Task LogInUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task LogOutUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegistrationUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            try
            {
                var result = await _userManager.CreateAsync(user, userDTO.PasswordHash);

                return result;
            }

            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
