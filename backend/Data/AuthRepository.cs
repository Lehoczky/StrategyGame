using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;

namespace backend.Data
{
    public interface IAuthRepository
    {
        Task<RegistrationResponseDto> register(RegistrationFormDto formData);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegistrationResponseDto> register(RegistrationFormDto formData)
        {
            if (formData == null)
                throw new NullReferenceException("Form data is null");

            var identityUser = new IdentityUser { UserName = formData.UserName };

            var result = await _userManager.CreateAsync(identityUser, formData.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return new RegistrationResponseDto { Message = String.Join("\n", errors) };
            }

            return new RegistrationResponseDto { Message = "User created successfuly" };
        }

    }
}