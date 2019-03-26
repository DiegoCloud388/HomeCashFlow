﻿using AutoMapper;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly IMapper _mapper;

        public ServiceAuthenticationUser(UserManager<User> userManager, SignInManager<UserDTO> signInManager, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task LogInUser(UserDTO userDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userDTO.UserName, userDTO.PasswordHash, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {

            }
        }

        public Task LogOutUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegistrationUser(UserDTO userDTO)
        {
            var user = Mapper.Map<User>(userDTO);

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callBackUrl = Url.Page("/Account/ConfirmEmail", page)
                await _signInManager.SignInAsync(userDTO, false);
            }

            return result;
        }
    }
}