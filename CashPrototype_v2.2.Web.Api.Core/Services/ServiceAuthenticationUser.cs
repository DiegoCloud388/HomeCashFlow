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
        //private SignInManager<UserDTO> _signInManager;
        private IMapper _mapper;

        public ServiceAuthenticationUser(UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //_signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public Task LogInUser(UserDTO userDTO)
        {
            //var result = await _signInManager.PasswordSignInAsync(
            //    userDTO.UserName, userDTO.PasswordHash, isPersistent: false, lockoutOnFailure: true);

            //if (result.Succeeded)
            //{

            //}

            throw new NotImplementedException();
        }

        public Task LogOutUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegistrationUser(UserDTO userDTO)
        {
            var user = Mapper.Map<User>(userDTO);
            try
            {
                var result = await _userManager.CreateAsync(user, user.PasswordHash);

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callBackUrl = Url.Page("/Account/ConfirmEmail", page)
                    //await _signInManager.SignInAsync(userDTO, false);
                }

                return result;
            }

            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
